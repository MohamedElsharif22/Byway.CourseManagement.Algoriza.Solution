using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Specifications.Instructor_Specs;
using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Entities.enums;
using Byway.Domain.Repositoies.Contract;
using Byway.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class InstructorService(IUnitOfWork unitOfWork, 
                                   IFileUploadService fileUploadService,
                                   IMapper mapper)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFileUploadService _fileUploadService = fileUploadService;
        private readonly IMapper _mapper = mapper;
        private readonly IInstructorRepository _instructorRepo = unitOfWork.Repository<Instructor, IInstructorRepository>();

        // Get All Instructors
        public async Task<(IEnumerable<InstructorResponse>, int)> GetAllInstructorsAsync(InstructorSpecParams specParams)
        {
            var insSpecs = new InstructorWithCoursesSpecifications(specParams);
            var instructors = await _instructorRepo.GetAllWithSpecsAsync(insSpecs);

            var countSpecs = new InstructorWithCoursesSpecifications(specParams, GetCountOnly: true);
            var count = await _instructorRepo.GetCountWithspecsAsync(countSpecs);
            var insDtoList = new List<InstructorResponse>();

            foreach (var i in instructors)
            {
                insDtoList.Add( await MapToInsReponse(i));
            }

            return (insDtoList, count);
        }


        public async Task<InstructorResponse?> GetInstructorByIdAsync(int instructorId)
        {
            var instructor = await _instructorRepo.GetByIdAsync(instructorId);
            if(instructor is null)
                return null;

            return await MapToInsReponse(instructor);
        }


        public async Task<(bool, string)> CreateInstructorAsync(InstructorRequest instructorRequest)
        {
            var instructor = new Instructor()
            {
                Name = instructorRequest.Name,
                About = instructorRequest.About,
                JopTitle = (JobTitles) instructorRequest.JopTitle,
                ProfilePictureUrl = await _fileUploadService.UploadImageAsync(instructorRequest.ProfilePicture,IFileUploadService.InstructorsImgFolder)
            };

            _instructorRepo.Add(instructor);
            
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
                return (false, "Error Occured while Adding instructor");

            return (true, $"{instructor.Name} Added Successfully!");

        }
        public async Task<(bool, string)> UpdateInstructorAsync(int insId, InstructorRequest instructorRequest)
        {
            var instructor = await _instructorRepo.GetByIdAsync(insId);

            if (instructor is null)
                return (false, "Can't find instructor!");

            var oldImgPath = instructor.ProfilePictureUrl;


            if(instructorRequest.ProfilePicture is not null)
            {
                instructor.ProfilePictureUrl = await _fileUploadService.UploadImageAsync(instructorRequest.ProfilePicture, 
                                                                                         IFileUploadService.InstructorsImgFolder);
            }
            


            instructor = _mapper.Map<Instructor>(instructor);

            _instructorRepo.Add(instructor);

            var result = await _unitOfWork.CompleteAsync();

            if(result == 0) 
            {
                _fileUploadService.DeleteImage(instructor.ProfilePictureUrl!);
                instructor.ProfilePictureUrl = oldImgPath;
                return (false, "Error occured while saving Changes!");
            }

            return (true, $"{instructor.Name} Updated Successfully!");

        }


        public IEnumerable<JobTitleReponse> GetAllJobTitles()
        {
            return Enum.GetValues<JobTitles>()
                       .Select(t => new JobTitleReponse { Title = t.ToString(), Value = (int)t });
        }

        

        #region Private
        private async Task<InstructorResponse> MapToInsReponse(Instructor instructor)
        {
            return new InstructorResponse
            {
                Id = instructor.Id,
                Name = instructor.Name,
                About = instructor.About,
                JopTitle = instructor.JopTitle.ToString(),
                ProfilePictureUrl = instructor.ProfilePictureUrl,
                CoursesCount = await _instructorRepo.GetCoursesCountAsync(instructor.Id),
                AverageRating = await _instructorRepo.GetAverageCourseRatingAsync(instructor.Id),
                StudentsCount = await _instructorRepo.GetStudentsCountForInstructorsAsync(instructor.Id),
                TotalLectures = await _instructorRepo.GetTotalLecturesForInstructorAsync(instructor.Id),
                CreatedAt = instructor.CreatedAt,
                UpdatedAt = instructor.UpdatedAt,
            };
        } 
        #endregion
    }
}
