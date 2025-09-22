namespace Byway.Domain.Entities.Checkout
{
    public class BoughtCourse : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CheckoutId { get; set; }
        public Checkout Checkout { get; set; }
    }
}