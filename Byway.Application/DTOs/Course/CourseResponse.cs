using Byway.Domain.Entities;
using Byway.Domain.Entities.Identity;

namespace Byway.Application.DTOs.Course
{
    public record CourseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string CoverPictureUrl { get; set; }
        public int LecturesCount { get; set; }
        public int DurationInMinutes { get; set; }
        public int? InstructorId { get; set; }
        public string InstructorName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
