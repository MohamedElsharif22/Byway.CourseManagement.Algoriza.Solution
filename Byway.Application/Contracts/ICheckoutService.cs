using Byway.Application.DTOs.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Contracts
{
    public interface ICheckoutService
    {
        Task<CheckoutResultDto> ProcessCheckoutFromCartAsync(string userId, string cartId, ProcessCheckoutRequest request);

        Task<IEnumerable<CheckoutHistoryDto>> GetUserCheckoutHistoryAsync(string userId);

        Task<CheckoutDetailsDto> GetCheckoutDetailsAsync(int checkoutId, string userId);

        Task<IEnumerable<EnrollmentResponse>> GetUserEnrollmentsAsync(string userId);

        Task<bool> IsUserEnrolledInCourseAsync(string userId, int courseId);

        Task<CheckoutSummaryDto> CalculateCheckoutSummaryFromCartAsync(string cartId);
    }
}
