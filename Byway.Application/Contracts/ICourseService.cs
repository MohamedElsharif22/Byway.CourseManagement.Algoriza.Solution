using Byway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Contracts
{
    public interface ICourseService 
    {
        Task<int> CreateCourseAsync(int userId, string title, string description);
        Task UpdateCourseAsync(int courseId, string title, string description);
        Task DeleteCourseAsync(int courseId);
        Task EnrollInCourseAsync(int userId, int courseId);
        Task UnenrollFromCourseAsync(int userId, int courseId);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<Course>> GetCoursesByUserIdAsync(int userId);
    }
}
