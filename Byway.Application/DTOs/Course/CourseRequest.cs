using Byway.Domain.Entities;
using Byway.Domain.Entities.Course_;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.Course
{
    public record CourseContentRequest
    {
        public int ContentId { get; set; }
        public string Name { get; set; }
        public int LecturesCount { get; set; }
        public int DurationInHours { get; set; }
    }
   
    public record CourseRequest
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MinLength(20)]
        public string Description { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Description("1 = Beginner, 2 = Intermediate, 3 = Advenced")]
        [Range(1,3)]
        public int CourseLevel { get; set; }
        [Required]
        public IFormFile CoverPicture { get; set; }
        [Required]
        public int InstructorId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string? Contents { get; set; }

    }
}
