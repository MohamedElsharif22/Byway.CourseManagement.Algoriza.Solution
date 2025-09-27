using Byway.Application.Contracts;
using Byway.Application.Specifications;
using Byway.Domain;
using Byway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application
{
    public class CourseService(IUnitOfWork unitOfWork) : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public Task<int> CreateCourseAsync(int userId, string title, string description)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourseAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task EnrollInCourseAsync(int userId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return _unitOfWork.Repository<Category>().GetAllAsync();
        }

        public async Task<(IReadOnlyList<Course>, int)> GetAllCoursesWithCountAsync(CourseSpecParams specParams)
        {
            var courseSpecs = new CourseWithInstructorAndCategorySpecifications(specParams);
            var courses = await _unitOfWork.Repository<Course>().GetAllWithSpecsAsync(courseSpecs);
            var countSpecs = new CourseWithInstructorAndCategorySpecifications(specParams, getCountOnly: true);
            var totalItems = await _unitOfWork.Repository<Course>().GetCountWithspecsAsync(countSpecs);
            return (courses, totalItems);
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
        {
            var specs = new CourseWithInstructorAndCategorySpecifications(c => c.Id == courseId);
            return await _unitOfWork.Repository<Course>().GetWithSpecsAsync(specs);
        }

        public Task<IReadOnlyList<Course>> GetCoursesByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UnenrollFromCourseAsync(int userId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCourseAsync(int courseId, string title, string description)
        {
            throw new NotImplementedException();
        }
    }
}
