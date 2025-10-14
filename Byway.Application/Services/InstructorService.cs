using AutoMapper;
using Byway.Application.Contracts;
using Byway.Application.Contracts.ExternalServices;
using Byway.Application.DTOs;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Specifications.Instructor_Specs;
using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Entities.enums;
using Byway.Domain.Repositoies.Contract;
using Byway.Domain.Specification;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class InstructorService(IUnitOfWork unitOfWork, 
                                   IFileUploadService fileUploadService,
                                   IMapper mapper,
                                   IConfiguration configuration) : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFileUploadService _fileUploadService = fileUploadService;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;
        private readonly IInstructorRepository _instructorRepo = unitOfWork.Repository<Instructor, IInstructorRepository>();

        public async Task<Pagination<InstructorResponse>> GetAllInstructorsAsync(InstructorSpecParams specParams)
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

            return new Pagination<InstructorResponse>(specParams.PageIndex, specParams.PageSize, count, insDtoList);
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
            var instructor = _mapper.Map<Instructor>(instructorRequest);

            instructor.ProfilePictureUrl = await _fileUploadService.UploadImageAsync(instructorRequest.ProfilePicture, 
                                                                                     IFileUploadService.InstructorsImgFolder);

            _instructorRepo.Add(instructor);
            
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                _fileUploadService.DeleteImage(instructor.ProfilePictureUrl);
                return (false, "Error Occured while Adding instructor");
            }

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
            
            _mapper.Map(instructorRequest,instructor);

            _instructorRepo.Update(instructor);

            var result = await _unitOfWork.CompleteAsync();

            if(result == 0) 
            {
                _fileUploadService.DeleteImage(instructor.ProfilePictureUrl!);
                instructor.ProfilePictureUrl = oldImgPath;
                return (false, "Error occured while saving Changes!");
            }

            return (true, $"{instructor.Name} Updated Successfully!");

        }



        public async Task<(bool, string)> DeleteInstructorAsync(int insId)
        {
            var spec = new InstructorWithCoursesSpecifications(i => i.Id == insId);
            var ins = await _instructorRepo.GetWithSpecsAsync(spec);

            if (ins is null) return (false, "Invalid Id!");

            var stdCount = await _instructorRepo.GetStudentsCountForInstructorsAsync(insId);

            if (stdCount > 0)
                return (false, "Cann't Delete instructor with courses that have students aleardy Enrolled in it.");

            var insImg = ins.ProfilePictureUrl;

            _instructorRepo.Delete(ins);

            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
                return (false, "Unable to save Changes!");

            return (true, $"{ins.Name} Deleted Successfully");

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
                ProfilePictureUrl = instructor.ProfilePictureUrl is null ? null : $"{_configuration["BaseApiUrl"]}/{instructor.ProfilePictureUrl}",
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
