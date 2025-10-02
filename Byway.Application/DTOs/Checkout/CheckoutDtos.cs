using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.DTOs.Checkout
{
    public class ProcessCheckoutRequest
    {
        public string PaymentMethod { get; set; }
        public string PaymentToken { get; set; }
    }

    // Response DTOs
    public class CheckoutResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? CheckoutId { get; set; }
        public string TransactionId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<int> EnrolledCourseIds { get; set; } = new List<int>();
    }

    public class CheckoutSummaryDto
    {
        public int TotalItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CheckoutItemDto> Items { get; set; } = new List<CheckoutItemDto>();
    }

    public class CheckoutItemDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverPictureUrl { get; set; }
    }

    public class CheckoutHistoryDto
    {
        public int Id { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public int CoursesCount { get; set; }
        public List<string> CourseNames { get; set; } = new List<string>();
    }

    public class CheckoutDetailsDto
    {
        public int Id { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public List<PurchasedCourseDto> Courses { get; set; } = new List<PurchasedCourseDto>();
    }

    public class PurchasedCourseDto
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PricePaid { get; set; }
        public string CoverPictureUrl { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset EnrolledAt { get; set; }
    }

    public class EnrollmentResponse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public string CoverPictureUrl { get; set; }
        public decimal PricePaid { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset EnrolledAt { get; set; }
        public string Status { get; set; }
        public int LecturesCount { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
