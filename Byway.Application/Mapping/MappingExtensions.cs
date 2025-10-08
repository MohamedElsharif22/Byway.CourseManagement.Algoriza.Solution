using Byway.Application.DTOs.Account;
using Byway.Application.DTOs.Course;
using Byway.Application.DTOs.Instructor;
using Byway.Domain.Entities.Cart;
using Byway.Domain.Entities.Course_;
using Byway.Domain.Entities.enums;
using Byway.Domain.Entities.Identity;

namespace Byway.Application.Mapping
{
    public static class MappingExtensions
    {
        #region CourseMapping
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

        public static CourseResponse ToCourseResponse(this Course course)
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
        #endregion

        #region CartMapping
        public static CartItem ToCartItem(this CourseResponse course)
        {
            return new CartItem
            {
                CourseId = course.Id,
                CourseName = course.Title,
                Price = course.Price,
                Category = course.CategoryName,
                CoverImgUrl = course.CoverPictureUrl
            };
        }
        #endregion

        #region UserMapping
        public static UserResponse ToUserResponse(this ApplicationUser user, string token)
        {
            return new UserResponse
            {
                Name = $"{user.FirstName} {user.LastName}",
                Email = user.Email!,
                Token = token
            };
        }
        #endregion

        #region Instructor
        
        #endregion
    }
}
