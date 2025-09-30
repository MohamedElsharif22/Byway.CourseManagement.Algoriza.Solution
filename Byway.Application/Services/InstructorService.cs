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
                insDtoList.Add(new InstructorResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    About = i.About,
                    JopTitle = i.JopTitle.ToString(),
                    ProfilePictureUrl = i.ProfilePictureUrl,
                    CoursesCount = await _instructorRepo.GetCoursesCountAsync(i.Id),
                    AverageRating = await _instructorRepo.GetAverageCourseRatingAsync(i.Id),
                    StudentsCount = await _instructorRepo.GetStudentsCountForInstructorsAsync(i.Id),
                    TotalLectures = await _instructorRepo.GetTotalLecturesForInstructorAsync(i.Id),
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt,
                });
            }

            return (insDtoList, count);
        }

        public async Task<Instructor?> GetInstructorAsync(int instructorId)
        {
            return await _instructorRepo.GetByIdAsync(instructorId);
        }

        public async Task<InstructorResponse?> GetInstructorStatsByIdAsync(int instructorId)
        {
            var instructor = await _instructorRepo.GetByIdAsync(instructorId);
            if(instructor is null)
                return null;

            return new InstructorResponse
            {
                Name = instructor.Name,
                About = instructor.About,
                JopTitle = instructor.JopTitle.ToString(),
                ProfilePictureUrl = instructor.ProfilePictureUrl,
                CoursesCount = await _instructorRepo.GetCoursesCountAsync(instructorId),
                AverageRating = await _instructorRepo.GetAverageCourseRatingAsync(instructorId),
                StudentsCount = await _instructorRepo.GetStudentsCountForInstructorsAsync(instructorId),
                TotalLectures = await _instructorRepo.GetTotalLecturesForInstructorAsync(instructorId),
            };
        }
        






    }
}
