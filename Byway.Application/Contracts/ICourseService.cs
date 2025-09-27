using Byway.Application.Specifications;
using Byway.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Contracts
{
    public interface ICourseService 
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<int> CreateCourseAsync(Course course, IFormFile coverPicture = null!);
        Task<int> UpdateCourseAsync(int courseId, Course course, IFormFile coverPicture = null!);
        Task<int> DeleteCourseAsync(int courseId);
        Task EnrollInCourseAsync(int userId, int courseId);
        Task UnenrollFromCourseAsync(int userId, int courseId);
        Task<(IReadOnlyList<Course>, int)> GetAllCoursesWithCountAsync(CourseSpecParams specParams);
        Task<Course?> GetCourseByIdAsync(int courseId);
        Task<IReadOnlyList<Course>> GetCoursesByUserIdAsync(int userId);
    }
}
