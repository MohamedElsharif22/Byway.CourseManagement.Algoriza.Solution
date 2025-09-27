using Byway.Application.Contracts;
using Byway.Application.Specifications;
using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application
{
    public class CourseService(IUnitOfWork unitOfWork, IFileUploadService fileUploadService) : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFileUploadService _fileUploadService = fileUploadService;
        private readonly IRepository<Course> _courseRepo = unitOfWork.Repository<Course>();

        public async Task<int> CreateCourseAsync(Course course, IFormFile coverPicture = null)
        {
            if (coverPicture != null)
            {
                if (!_fileUploadService.IsValidImageFile(coverPicture))
                    throw new InvalidOperationException("Invalid image file. Please upload a valid image file (JPG, PNG, GIF, WebP) under 5MB.");

                course.CoverPictureUrl = await _fileUploadService.UploadImageAsync(coverPicture, "courses");
            }

            _courseRepo.Add(course);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0 && !string.IsNullOrEmpty(course.CoverPictureUrl))
            {
                _fileUploadService.DeleteImage(course.CoverPictureUrl);
            }

            return result;
        }

        public async Task<int> UpdateCourseAsync(int courseId, Course updatedCourse, IFormFile coverPicture = null)
        {
          
            var existingCourse = await GetCourseByIdAsync(courseId);
            if (existingCourse == null)
                return 0;

            var oldImagePath = existingCourse.CoverPictureUrl;

            if (coverPicture != null)
            {
                if (!_fileUploadService.IsValidImageFile(coverPicture))
                    throw new InvalidOperationException("Invalid image file. Please upload a valid image file (JPG, PNG, GIF, WebP) under 5MB.");

                updatedCourse.CoverPictureUrl = await _fileUploadService.UploadImageAsync(coverPicture, "courses");
            }
            else
            {
                updatedCourse.CoverPictureUrl = existingCourse.CoverPictureUrl;
            }

            ApplyCourseChanges(ref existingCourse, ref updatedCourse);


            _courseRepo.Update(existingCourse);
            var result = await _unitOfWork.CompleteAsync();

            if (!(result > 0 && coverPicture != null && !string.IsNullOrEmpty(oldImagePath)))
            {
                if (coverPicture != null && !string.IsNullOrEmpty(updatedCourse.CoverPictureUrl))
                {
                    _fileUploadService.DeleteImage(updatedCourse.CoverPictureUrl);
                }
                throw new InvalidOperationException("Course update failed.");
            }

            _fileUploadService.DeleteImage(oldImagePath);
            return result;
            
        }


        public async Task<int> DeleteCourseAsync(int courseId)
        {
            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course is null)
                return 0;

            _courseRepo.Delete(course);
            return await _unitOfWork.CompleteAsync();
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

        private void ApplyCourseChanges(ref Course existingCourse, ref Course updatedCourse)
        {
            existingCourse.Title = updatedCourse.Title;
            existingCourse.Description = updatedCourse.Description;
            existingCourse.Rating = updatedCourse.Rating;
            existingCourse.Price = updatedCourse.Price;
            existingCourse.InstructorId = updatedCourse.InstructorId;
            existingCourse.CategoryId = updatedCourse.CategoryId;
            existingCourse.CoverPictureUrl = updatedCourse.CoverPictureUrl;
            existingCourse.UpdatedAt = DateTime.UtcNow;
        }

    }
}
