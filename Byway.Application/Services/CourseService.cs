using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.DTOs;
using Byway.Application.DTOs.Category;
using Byway.Application.DTOs.Course;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Mapping;
using Byway.Application.Specifications;
using Byway.Application.Specifications.Course_Specs;
using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Entities.Course_;
using Byway.Domain.Entities.enums;
using Byway.Domain.Repositoies.Contract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

            var contents = JsonSerializer.Deserialize<List<CourseContentRequest>>(courseRequest.Contents);

            if (contents is null || !contents.Any())
                throw new InvalidDataException("Course must have at least one content.");

            var coverPicture = courseRequest.CoverPicture;

            var cat = await _unitOfWork.Repository<Category>().GetByIdAsync(courseRequest.CategoryId) 
                    ?? throw new InvalidDataException("Parameter: CategoryId is not valid!");

            var instructor = await _unitOfWork.Repository<Instructor>().GetByIdAsync(courseRequest.InstructorId)
                          ?? throw new InvalidDataException("Parameter: CategoryId is not valid!");

            var courseEntity = _mapper.Map<Course>(courseRequest);

            if (coverPicture != null)
            {
                courseEntity.CoverPictureUrl = await _fileUploadService.UploadImageAsync(coverPicture, IFileUploadService.CoursesImgFolder);
            }

            _courseRepo.Add(courseEntity);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                if (!string.IsNullOrEmpty(courseEntity.CoverPictureUrl))
                {
                    _fileUploadService.DeleteImage(courseEntity.CoverPictureUrl);
                }
            }
            else
            {
                foreach(var content in contents)
                {
                    courseEntity.Contents.Add(_mapper.Map<CourseContent>(content));
                }

                result = await _unitOfWork.CompleteAsync();

                if (result == 0)
                {
                    _fileUploadService.DeleteImage(courseEntity.CoverPictureUrl);
                    _courseRepo.Delete(courseEntity);
                }

                await _unitOfWork.CompleteAsync();
            }


            return result;
        }

        public async Task<int> UpdateCourseAsync(int courseId, CourseRequest courseRequest)
        {

            var contents = JsonSerializer.Deserialize<List<CourseContentRequest>>(courseRequest.Contents);
            
            if(contents is null || !contents.Any())
                throw new InvalidDataException("Course must have at least one content.");

            var coverPicture = courseRequest.CoverPicture;

            var specs = new CourseWithInstructorAndCategorySpecifications(c => c.Id == courseId);

            var existingCourse = await _courseRepo.GetWithSpecsAsync(specs);
            if (existingCourse == null)
                return 0;


            var oldImagePath = existingCourse.CoverPictureUrl;

            _mapper.Map(courseRequest,existingCourse);

            if (coverPicture != null)
            {
                if (!_fileUploadService.IsValidImageFile(coverPicture))
                    throw new InvalidOperationException("Invalid image file. Please upload a valid image file (JPG, PNG, GIF, WebP) under 5MB.");

                existingCourse.CoverPictureUrl = await _fileUploadService.UploadImageAsync(coverPicture, IFileUploadService.CoursesImgFolder);
            }

            _courseRepo.Update(existingCourse);

            foreach (var content in contents)
            {
                var contentEntity = existingCourse.Contents.FirstOrDefault(c => c.Id == content.ContentId);
                if (contentEntity is null)
                    continue;

                _mapper.Map(content, contentEntity);

                _unitOfWork.Repository<CourseContent>().Update(contentEntity);
            }


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
            var spec = new CourseWithInstructorAndCategorySpecifications(c => c.Id == courseId);
            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course is null)
                return 0;

            if (course.Enrollments.Count > 0)
                throw new InvalidOperationException($"Unable To Delete Course With Enrollments");

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

        public async Task<Pagination<CourseResponse>> GetAllCoursesWithCountAsync(CourseSpecParams specParams)
        {
            var courseSpecs = new CourseWithInstructorAndCategorySpecifications(specParams);
            var courses = await _unitOfWork.Repository<Course>().GetAllWithSpecsAsync(courseSpecs);
            var countSpecs = new CourseWithInstructorAndCategorySpecifications(specParams, getCountOnly: true);
            var totalItems = await _unitOfWork.Repository<Course>().GetCountWithspecsAsync(countSpecs);

            var coursesResponse = courses.Select(c => _mapper.Map<CourseResponse>(c));



            foreach (var course in coursesResponse)
            {
                course.Contents = [.. courses.First(c => c.Id == course.Id).Contents.Select(c => _mapper.Map<CourseContentResponse>(c))];
            }

            var page = new Pagination<CourseResponse>(specParams.PageIndex, 
                                                      specParams.PageSize, 
                                                      totalItems, coursesResponse);

            return page;
        }

        public async Task<CourseResponse?> GetCourseByIdAsync(int courseId)
        {
            var specs = new CourseWithInstructorAndCategorySpecifications(c => c.Id == courseId);
            var course = await _unitOfWork.Repository<Course>().GetWithSpecsAsync(specs);
            return _mapper.Map<CourseResponse>(course);
        }

        public IEnumerable<CourseLevelResponse> GetCourseLevels()
        {
            return Enum.GetValues<CourseLevels>()
                       .Select(t => new CourseLevelResponse { Level = t.ToString(), Value = (int)t });
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
