using Byway.CourseManagement.Algoriza.API.DTOs;
using Byway.Domain.Entities;

namespace Byway.CourseManagement.Algoriza.API.Extensions
{
    public static class MappingExtensions
    {
        public static Course ToCourseEntity(this CourseRequest request)
        {
            return new Course
            {
                Title = request.Title,
                Description = request.Description,
                Rating = request.Rating,
                Price = request.Price,
                InstructorId = request.InstructorId,
                CategoryId = request.CategoryId,
            };
        }

        public static CourseResponse CourseResponse(this Course course)
        {
            return new CourseResponse
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Rating = course.Rating,
                Price = course.Price,
                CoverPictureUrl = course.CoverPictureUrl,
                InstructorId = course.InstructorId,
                CategoryId = course.CategoryId,
                CreatedAt = course.CreatedAt,
                UpdatedAt = course.UpdatedAt,
            };
        }
    }
}
