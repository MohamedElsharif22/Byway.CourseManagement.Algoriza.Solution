using Byway.Application.Specifications.Enums;
using Byway.Domain.Entities;
using Byway.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Specifications
{
    internal class CourseWithInstructorAndCategorySpecifications : BaseSpecification<Course>
    {
        public CourseWithInstructorAndCategorySpecifications(CourseSpecParams courseSpecParams, bool getCountOnly = false)
            : base(p => 
                        (string.IsNullOrEmpty(courseSpecParams.Search) || EF.Functions.Like(p.Title, $"%{courseSpecParams.Search}%"))
                        && (!courseSpecParams.CategoryId.HasValue || p.CategoryId == courseSpecParams.CategoryId)
                        && (!courseSpecParams.InstructorId.HasValue || p.InstructorId == courseSpecParams.InstructorId)
                  )
        {
            if (!getCountOnly)
            {
                AddInclude(c => c.Instructor);
                AddInclude(c => c.Category);

                if (courseSpecParams.Sort.HasValue)
                {
                    switch (courseSpecParams.Sort)
                    {
                        case (byte) SortingEnum.PriceAsc:
                            AddOrderByAsc(P => P.Price);
                            break;
                        case (byte) SortingEnum.PriceDesc:
                            AddOrderByDesc(P => P.Price);
                            break;
                        case (byte) SortingEnum.RatingAsc:
                            AddOrderByAsc(P => P.Rating);
                            break;
                        case (byte) SortingEnum.RatingDesc:
                            AddOrderByDesc(P => P.Rating);
                            break;
                        case (byte) SortingEnum.Oldest:
                            AddOrderByAsc(P => P.CreatedAt);
                            break;
                        case (byte) SortingEnum.Newest:
                            AddOrderByDesc(P => P.CreatedAt);
                            break;
                        default:
                            AddOrderByDesc(P => P.CreatedAt);
                            break;
                    }
                }
                else { AddOrderByAsc(P => P.CreatedAt); }

                ApplyPagination((courseSpecParams.PageIndex - 1) * courseSpecParams.PageSize, courseSpecParams.PageSize);
            }

        }

        public CourseWithInstructorAndCategorySpecifications(Expression<Func<Course, bool>>? criteria) : base(criteria)
        {
            AddInclude(c => c.Instructor);
            AddInclude(c => c.Category);
        }
    }
}
