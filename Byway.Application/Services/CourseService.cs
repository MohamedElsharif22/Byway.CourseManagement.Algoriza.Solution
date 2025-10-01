using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.DTOs;
using Byway.Application.DTOs.Course;
using Byway.Application.Mapping;
using Byway.Application.Specifications;
using Byway.Application.Specifications.Course_Specs;
using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class CourseService(IUnitOfWork unitOfWork, 
                               IFileUploadService fileUploadService,
                               IMapper mapper) : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFileUploadService _fileUploadService = fileUploadService;
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Course> _courseRepo = unitOfWork.Repository<Course>();

        public async Task<int> CreateCourseAsync(CourseRequest courseRequest)
        {
            var coverPicture = courseRequest.CoverPicture;

            var cat = await _unitOfWork.Repository<Category>().GetByIdAsync(courseRequest.CategoryId);

            if (cat is null)
                throw new InvalidDataException("Parameter: CategoryId is not valid!");

            var instructor = await _unitOfWork.Repository<Instructor>().GetByIdAsync(courseRequest.InstructorId);

            if (instructor is null)
                throw new InvalidDataException("Parameter: CategoryId is not valid!");

            var courseEntity = _mapper.Map<Course>(courseRequest);

            if (coverPicture != null)
            {
                if (!_fileUploadService.IsValidImageFile(coverPicture))
                    throw new InvalidOperationException("Invalid image file. Please upload a valid image file (JPG, PNG, GIF, WebP) under 5MB.");

                courseEntity.CoverPictureUrl = await _fileUploadService.UploadImageAsync(coverPicture, "courses");
            }

            _courseRepo.Add(courseEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0 && !string.IsNullOrEmpty(courseEntity.CoverPictureUrl))
            {
                _fileUploadService.DeleteImage(courseEntity.CoverPictureUrl);
            }

            return result;
        }

        public async Task<int> UpdateCourseAsync(int courseId, CourseRequest courseRequest)
        {
            var coverPicture = courseRequest.CoverPicture;

            var existingCourse = await _courseRepo.GetByIdAsync(courseId);
            if (existingCourse == null)
                return 0;


            var oldImagePath = existingCourse.CoverPictureUrl;

            existingCourse = _mapper.Map<Course>(courseRequest);

            if (coverPicture != null)
            {
                if (!_fileUploadService.IsValidImageFile(coverPicture))
                    throw new InvalidOperationException("Invalid image file. Please upload a valid image file (JPG, PNG, GIF, WebP) under 5MB.");

                existingCourse.CoverPictureUrl = await _fileUploadService.UploadImageAsync(coverPicture, "courses");
            }


            _courseRepo.Update(existingCourse);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0 && coverPicture is null)

            {
                existingCourse.CoverPictureUrl = oldImagePath;
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

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
            return categories.Select(c => _mapper.Map<CategoryResponse>(c));
        }

        public async Task<(IEnumerable<CourseResponse>, int)> GetAllCoursesWithCountAsync(CourseSpecParams specParams)
        {
            var courseSpecs = new CourseWithInstructorAndCategorySpecifications(specParams);
            var courses = await _unitOfWork.Repository<Course>().GetAllWithSpecsAsync(courseSpecs);
            var countSpecs = new CourseWithInstructorAndCategorySpecifications(specParams, getCountOnly: true);
            var totalItems = await _unitOfWork.Repository<Course>().GetCountWithspecsAsync(countSpecs);
            return (courses.Select(c => _mapper.Map<CourseResponse>(c)), totalItems);
        }

        public async Task<CourseResponse?> GetCourseByIdAsync(int courseId)
        {
            var specs = new CourseWithInstructorAndCategorySpecifications(c => c.Id == courseId);
            var course = await _unitOfWork.Repository<Course>().GetWithSpecsAsync(specs);
            return _mapper.Map<CourseResponse>(course);
        }

        public Task<IEnumerable<CourseResponse>> GetCoursesByUserIdAsync(int userId)
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
