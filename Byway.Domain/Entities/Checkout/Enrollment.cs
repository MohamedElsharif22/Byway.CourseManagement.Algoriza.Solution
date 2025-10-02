using Byway.Domain.Entities.enums;
using Byway.Domain.Entities.Identity;

namespace Byway.Domain.Entities.Checkout
{
    public class Enrollment : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CheckoutId { get; set; }
        public Checkout Checkout { get; set; }
        public decimal PricePaid { get; set; }
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
    }
}