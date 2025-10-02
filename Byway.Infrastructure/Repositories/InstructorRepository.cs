using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Byway.Domain.Specification;
using Byway.Infrastructure._Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure.Repositories
{
    public class InstructorRepository(BywayDbContext context) : Repository<Instructor>(context), IInstructorRepository
    {
        private readonly DbSet<Instructor> _instructors = context.Instructors;

        public async Task<decimal> GetAverageCourseRatingAsync(int instructorId)
        {
            var query = _instructors.Where(i => i.Id == instructorId)
                     .SelectMany(i => i.Courses)
                     .Select(c => c.Rating);

            return await query.AnyAsync()
                ? await query.AverageAsync(r => r * 1.0m)
                : 0m;
        }

        public async Task<int> GetCoursesCountAsync(int instructorId)
        {
            return await _instructors.Where(i => i.Id == instructorId)
                                     .SelectMany(i => i.Courses)
                                     .CountAsync();
        }

        public async Task<int> GetStudentsCountForInstructorsAsync(int instructorId)
        {
            return await _instructors.Where(i => i.Id == instructorId)
                         .SelectMany(i => i.Courses)
                         .SelectMany(c => c.Enrollments)
                         .Select(u => u.Id)
                         .Distinct()
                         .CountAsync();
        }

        public async Task<int> GetTotalLecturesForInstructorAsync(int instructorId)
        {
            return await _instructors.Where(i => i.Id == instructorId)
                                     .SelectMany(i => i.Courses)
                                     .SumAsync(c => c.LecturesCount);
        }

    }
}
