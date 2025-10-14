using Byway.Domain.Entities;
using Byway.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.Course
{
    public record CourseContentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LecturesCount { get; set; }
        public int DurationInHours { get; set; }
    }
    public record CourseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string CoverPictureUrl { get; set; }
        public string Level { get; set; }
        public int LecturesCount { get; set; }
        public int DurationInHours { get; set; }
        public int? InstructorId { get; set; }
        public string InstructorName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<CourseContentResponse> Contents { get; set; } = new List<CourseContentResponse>();
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public record CourseLevelResponse
    {
        public string Level { get; set; }
        public int Value { get; set; }
    }
}
