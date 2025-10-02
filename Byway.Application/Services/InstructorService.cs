using Byway.Application.DTOs.Instructor;
using Byway.Application.Specifications.Instructor_Specs;
using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Byway.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class InstructorService(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
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
    }
}
