using Byway.Domain.Entities;
using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.Course
{
    public record CourseRequest
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MinLength(100)]
        public string Description { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public IFormFile CoverPicture { get; set; }
        [Required]
        public int InstructorId { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
