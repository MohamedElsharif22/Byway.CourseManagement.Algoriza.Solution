using Byway.Application.DTOs;
using Byway.Application.DTOs.Course;
using Byway.Application.Specifications.Course_Specs;
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
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        Task<int> CreateCourseAsync(CourseRequest course);
        Task<int> UpdateCourseAsync(int courseId, CourseRequest course);
        Task<int> DeleteCourseAsync(int courseId);
        Task EnrollInCourseAsync(int userId, int courseId);
        Task UnenrollFromCourseAsync(int userId, int courseId);
        Task<Pagination<CourseResponse>> GetAllCoursesWithCountAsync(CourseSpecParams specParams);
        Task<CourseResponse?> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseResponse>> GetCoursesByUserIdAsync(int userId);
    }
}
