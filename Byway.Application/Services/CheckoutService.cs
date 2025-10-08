using Byway.Application.Contracts;
using Byway.Application.DTOs.Checkout;
using Byway.Application.Specifications.Checkout_Specs;
using Byway.Domain;
using Byway.Domain.Entities.Checkout;
using Byway.Domain.Entities.Course_;
using Byway.Domain.Entities.enums;
using Byway.Domain.Repositoies.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;
        private const decimal TaxRate = ICartRepository.TaxRate;

        public CheckoutService(IUnitOfWork unitOfWork, ICartRepository cartRepository)
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
        }

        public async Task<CheckoutResultDto> ProcessCheckoutFromCartAsync(
            string userId,
            string cartId,
            ProcessCheckoutRequest request)
        {
            // Get cart
            var cart = await _cartRepository.GetCartAsync(cartId);
            if (cart is null || cart.Items.Count == 0)
            {
                return new CheckoutResultDto
                {
                    Success = false,
                    Message = "Cart is empty or not found."
                };
            }

            // Validate payment info
            if (string.IsNullOrWhiteSpace(request.PaymentMethod) ||
                string.IsNullOrWhiteSpace(request.PaymentToken))
            {
                return new CheckoutResultDto
                {
                    Success = false,
                    Message = "Invalid payment information."
                };
            }

            // Check if user is already enrolled in any of the cart courses
            var courseIds = cart.Items.Select(i => i.CourseId).ToList();
            var alreadyEnrolled = await _unitOfWork.Repository<Enrollment>()
                .GetAllWithSpecsAsync(new EnrollmentByUserAndCoursesSpec(userId, courseIds));

            if (alreadyEnrolled.Any())
            {
                var enrolledCourseIds = alreadyEnrolled.Select(e => e.CourseId).ToList();
                var enrolledTitles = cart.Items
                    .Where(i => enrolledCourseIds.Contains(i.CourseId))
                    .Select(i => i.CourseName);

                return new CheckoutResultDto
                {
                    Success = false,
                    Message = $"You are already enrolled in: {string.Join(", ", enrolledTitles)}"
                };
            }

            // Get actual course details from database
            var courses = await _unitOfWork.Repository<Course>()
                .GetAllWithSpecsAsync(new CoursesByIdsSpec(courseIds));

            if (courses.Count() != cart.Items.Count)
            {
                return new CheckoutResultDto
                {
                    Success = false,
                    Message = "Some courses in your cart no longer exist."
                };
            }

            // Calculate totals
            var subTotal = courses.Sum(c => c.Price);
            var tax = subTotal * TaxRate;
            var totalPrice = subTotal + tax;

            // Process payment (mock)
            var transactionId = await ProcessPaymentAsync(
                request.PaymentToken,
                totalPrice,
                request.PaymentMethod);

            if (string.IsNullOrEmpty(transactionId))
            {
                return new CheckoutResultDto
                {
                    Success = false,
                    Message = "Payment processing failed. Please try again."
                };
            }

            // Create checkout record
            var checkout = new Checkout
            {
                UserId = userId,
                SubTotal = subTotal,
                Tax = tax,
                TotalPrice = totalPrice,
                PaymentMethod = request.PaymentMethod,
                PaymentTransactionId = transactionId,
                Status = CheckoutStatus.Completed,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            _unitOfWork.Repository<Checkout>().Add(checkout);
            await _unitOfWork.CompleteAsync();

            // Create enrollments
            var enrollments = courses.Select(course => new Enrollment
            {
                CourseId = course.Id,
                UserId = userId,
                CheckoutId = checkout.Id,
                PricePaid = course.Price,
                Status = EnrollmentStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            }).ToList();

            foreach (var enrollment in enrollments)
            {
                _unitOfWork.Repository<Enrollment>().Add(enrollment);
            }

            await _unitOfWork.CompleteAsync();

            // Clear cart
            _cartRepository.DeleteCart(cartId);

            return new CheckoutResultDto
            {
                Success = true,
                Message = "Purchase completed successfully! You are now enrolled in the courses.",
                CheckoutId = checkout.Id,
                TransactionId = transactionId,
                TotalAmount = totalPrice,
                EnrolledCourseIds = courseIds
            };
        }

        public async Task<IEnumerable<CheckoutHistoryResponse>> GetUserCheckoutHistoryAsync(string userId)
        {
            var checkouts = await _unitOfWork.Repository<Domain.Entities.Checkout.Checkout>()
                .GetAllWithSpecsAsync(new CheckoutByUserSpec(userId));

            return checkouts.Select(c => new CheckoutHistoryResponse
            {
                Id = c.Id,
                PurchaseDate = c.CreatedAt,
                TotalAmount = c.TotalPrice,
                PaymentMethod = c.PaymentMethod,
                Status = c.Status.ToString(),
                CoursesCount = c.PurchasedCourses?.Count ?? 0,
                CourseNames = c.PurchasedCourses?.Select(p => p.Course.Title).ToList() ?? new List<string>()
            }).ToList();
        }

        public async Task<CheckoutDetailsResponse> GetCheckoutDetailsAsync(int checkoutId, string userId)
        {
            var checkout = await _unitOfWork.Repository<Domain.Entities.Checkout.Checkout>()
                .GetWithSpecsAsync(new CheckoutDetailsSpec(checkoutId, userId));

            if (checkout == null)
                return null;

            return new CheckoutDetailsResponse
            {
                Id = checkout.Id,
                PurchaseDate = checkout.CreatedAt,
                SubTotal = checkout.SubTotal,
                Tax = checkout.Tax,
                TotalPrice = checkout.TotalPrice,
                PaymentMethod = checkout.PaymentMethod,
                TransactionId = checkout.PaymentTransactionId,
                Status = checkout.Status.ToString(),
                Courses = checkout.PurchasedCourses.Select(e => new PurchasedCourseResponse
                {
                    EnrollmentId = e.Id,
                    CourseId = e.Course.Id,
                    Title = e.Course.Title,
                    Description = e.Course.Description,
                    PricePaid = e.PricePaid,
                    CoverPictureUrl = e.Course.CoverPictureUrl,
                    InstructorName = e.Course.Instructor?.Name,
                    CategoryName = e.Course.Category?.Name,
                    EnrolledAt = e.CreatedAt
                }).ToList()
            };
        }

        public async Task<IEnumerable<EnrollmentResponse>> GetUserEnrollmentsAsync(string userId)
        {
            var enrollments = await _unitOfWork.Repository<Enrollment>()
                .GetAllWithSpecsAsync(new EnrollmentsByUserSpec(userId));

            return enrollments.Select(e => new EnrollmentResponse
            {
                Id = e.Id,
                CourseId = e.Course.Id,
                CourseTitle = e.Course.Title,
                CourseDescription = e.Course.Description,
                CoverPictureUrl = e.Course.CoverPictureUrl,
                PricePaid = e.PricePaid,
                InstructorName = e.Course.Instructor?.Name,
                CategoryName = e.Course.Category?.Name,
                EnrolledAt = e.CreatedAt,
                Status = e.Status.ToString(),
            }).ToList();
        }

        public async Task<bool> IsUserEnrolledInCourseAsync(string userId, int courseId)
        {
            var enrollment = await _unitOfWork.Repository<Enrollment>()
                .GetWithSpecsAsync(new EnrollmentByUserAndCourseSpec(userId, courseId));

            return enrollment != null;
        }

        public async Task<CheckoutSummaryResponse> CalculateCheckoutSummaryFromCartAsync(string cartId)
        {
            var cart = await _cartRepository.GetCartAsync(cartId);

            if (cart == null || !cart.Items.Any())
            {
                return new CheckoutSummaryResponse
                {
                    TotalItems = 0,
                    SubTotal = 0,
                    Tax = 0,
                    TaxRate = TaxRate,
                    TotalPrice = 0
                };
            }

            var subTotal = cart.Items.Sum(i => i.Price);
            var tax = subTotal * TaxRate;

            return new CheckoutSummaryResponse
            {
                TotalItems = cart.Items.Count,
                SubTotal = subTotal,
                Tax = tax,
                TaxRate = TaxRate,
                TotalPrice = subTotal + tax,
                Items = cart.Items.Select(i => new CheckoutItemResponse
                {
                    CourseId = i.CourseId,
                    Title = i.CourseName,
                    Price = i.Price,
                    CoverPictureUrl = i.CoverImgUrl
                }).ToList()
            };
        }

        #region Private Methods

        private async Task<string> ProcessPaymentAsync(
            string paymentToken,
            decimal amount,
            string paymentMethod)
        {
            // Mock payment processing
            // In production, integrate with Stripe, PayPal, etc.
            await Task.Delay(100); // Simulate API call

            if (string.IsNullOrWhiteSpace(paymentToken) || amount <= 0)
                return null;

            // Generate mock transaction ID
            return $"TXN-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        }

        #endregion
    }
}
