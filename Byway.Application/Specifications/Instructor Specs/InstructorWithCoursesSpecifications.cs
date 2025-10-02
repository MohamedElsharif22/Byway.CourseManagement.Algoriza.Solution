using Byway.Domain.Entities;
using Byway.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Specifications.Instructor_Specs
{
    public class InstructorWithCoursesSpecifications : BaseSpecification<Instructor>
    {
        public InstructorWithCoursesSpecifications(InstructorSpecParams specParams, bool GetCountOnly = false)
                : base( I => (string.IsNullOrWhiteSpace(specParams.Search) || EF.Functions.Like(I.Name,$"%{specParams.Search}%")))
        {
            if (!GetCountOnly) 
            { 
                AddInclude(i => i.Courses);
                ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
            }
        }

        public InstructorWithCoursesSpecifications(Expression<Func<Instructor, bool>> expression) 
                : base(expression) 
        {
            AddInclude(i => i.Courses);
        }
    }
}
