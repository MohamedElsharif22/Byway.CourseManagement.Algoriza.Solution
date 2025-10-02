using Byway.Application.Contracts;
using Byway.Application.DTOs.Checkout;
using Byway.CourseManagement.Algoriza.API.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    [Authorize]
    public class CheckoutController(ICheckoutService checkoutService) : BaseApiController
    {
        private readonly ICheckoutService _checkoutService = checkoutService;

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [EndpointSummary("Calculate checkout summary from cart (before processing)")]
        [HttpGet("summary/{cartId}")]
        [AllowAnonymous]
        public async Task<ActionResult<CheckoutSummaryDto>> GetCheckoutSummary(string cartId)
        {

            var summary = await _checkoutService.CalculateCheckoutSummaryFromCartAsync(cartId);
            return Ok(summary);

        }

        [EndpointSummary("Process checkout from cart and complete purchase")]
        [HttpPost("process/{cartId}")]
        [Authorize("User")]
        public async Task<ActionResult<CheckoutResultDto>> ProcessCheckout(
            string cartId,
            [FromBody] ProcessCheckoutRequest request)
        {
                var userId = GetUserId();
                var result = await _checkoutService.ProcessCheckoutFromCartAsync(userId, cartId, request);

                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
        }


        [HttpGet("history")]
        [EndpointSummary("Get user's purchase history")]
        [ProducesResponseType(typeof(IEnumerable<CheckoutHistoryDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 500)]

        public async Task<ActionResult<IEnumerable<CheckoutHistoryDto>>> GetCheckoutHistory()
        {

                var userId = GetUserId();
                var history = await _checkoutService.GetUserCheckoutHistoryAsync(userId);
                return Ok(history);
        }


        [EndpointSummary("Get detailed information about a specific checkout/purchase")]
        [ProducesResponseType(typeof(CheckoutDetailsDto), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        [HttpGet("{checkoutId}")]
        public async Task<ActionResult<CheckoutDetailsDto>> GetCheckoutDetails(int checkoutId)
        {
                var userId = GetUserId();
                var details = await _checkoutService.GetCheckoutDetailsAsync(checkoutId, userId);

                if (details == null)
                    return NotFound(new ApiResponse(404, "Checkout not found or you don't have access to it."));

                return Ok(details);
        }

        [EndpointSummary("Get all courses the user is enrolled in")]
        [HttpGet("enrollments")]
        [ProducesResponseType(typeof(IEnumerable<EnrollmentResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 500)]
        public async Task<ActionResult<IEnumerable<EnrollmentResponse>>> GetMyEnrollments()
        {
                var userId = GetUserId();
                var enrollments = await _checkoutService.GetUserEnrollmentsAsync(userId);
                return Ok(enrollments);

        }

        [HttpGet("is-enrolled/{courseId}")]
        [EndpointSummary("Check if user is enrolled in a specific course")]
        public async Task<ActionResult<bool>> IsEnrolledInCourse(int courseId)
        {
            var userId = GetUserId();
            var isEnrolled = await _checkoutService.IsUserEnrolledInCourseAsync(userId, courseId);
            return Ok(new { courseId, isEnrolled });
        }
    }
}
