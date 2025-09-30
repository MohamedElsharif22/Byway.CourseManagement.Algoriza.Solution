using Byway.Domain.Entities;
using Byway.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Repositoies.Contract
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<int> GetTotalLecturesForInstructorAsync(int instructorId);
        Task<int> GetStudentsCountForInstructorsAsync(int instructorId);
        Task<int> GetCoursesCountAsync(int instructorId);
        Task<decimal> GetAverageCourseRatingAsync(int instructorId);
    }
}
