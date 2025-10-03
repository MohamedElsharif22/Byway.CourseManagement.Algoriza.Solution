using Byway.Application.DTOs;
using Byway.Application.DTOs.Instructor;
using Byway.Application.Specifications.Instructor_Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Contracts
{
    public interface IInstructorService
    {
        Task<Pagination<InstructorResponse>> GetAllInstructorsAsync(InstructorSpecParams specParams);
        Task<InstructorResponse?> GetInstructorByIdAsync(int instructorId);
        Task<(bool, string)> CreateInstructorAsync(InstructorRequest instructorRequest);
        Task<(bool, string)> UpdateInstructorAsync(int insId, InstructorRequest instructorRequest);
        Task<(bool, string)> DeleteInstructorAsync(int insId);
        IEnumerable<JobTitleReponse> GetAllJobTitles();
    }
}
