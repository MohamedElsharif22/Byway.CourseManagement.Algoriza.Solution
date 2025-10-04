using Byway.Domain.Entities;
using Byway.Domain.Entities.Checkout;
using Byway.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Specifications.Checkout_Specs
{
    // Get enrollments by user and specific courses
    public class EnrollmentByUserAndCoursesSpec : BaseSpecification<Enrollment>
    {
        public EnrollmentByUserAndCoursesSpec(string userId, List<int> courseIds)
            : base(e => e.UserId == userId && courseIds.Contains(e.CourseId))
        {
        }
    }

    // Get courses by IDs
    public class CoursesByIdsSpec : BaseSpecification<Course>
    {
        public CoursesByIdsSpec(List<int> courseIds)
            : base(c => courseIds.Contains(c.Id))
        {
            AddInclude(c => c.Instructor);
            AddInclude(c => c.Category);
        }
    }

    // Get checkout history by user
    public class CheckoutByUserSpec : BaseSpecification<Checkout>
    {
        public CheckoutByUserSpec(string userId)
            : base(c => c.UserId == userId)
        {
            AddInclude(q => q.Include(c => c.PurchasedCourses).ThenInclude(pc => pc.Course));

            AddOrderByDesc(c => c.CreatedAt);
        }
    }

    // Get checkout details by ID and user
    public class CheckoutDetailsSpec : BaseSpecification<Checkout>
    {
        public CheckoutDetailsSpec(int checkoutId, string userId)
            : base(c => c.Id == checkoutId && c.UserId == userId)
        {
            AddInclude(c => c.PurchasedCourses);
            AddInclude(q => q.Include(c => c.PurchasedCourses)
                             .ThenInclude(p => p.Course)
                             .ThenInclude(c => c.Instructor));

            AddInclude(q => q.Include(c => c.PurchasedCourses)
                             .ThenInclude(p => p.Course)
                             .ThenInclude(c => c.Category));
        }
    }

    // Get all enrollments by user
    public class EnrollmentsByUserSpec : BaseSpecification<Enrollment>
    {
        public EnrollmentsByUserSpec(string userId)
            : base(e => e.UserId == userId)
        {
            AddInclude(q => q.Include(c => c.Course).ThenInclude(e => e.Category));
            AddInclude(q => q.Include(c => c.Course).ThenInclude(e => e.Instructor));
            AddOrderByDesc(e => e.CreatedAt);
        }
    }

    // Check if user enrolled in specific course
    public class EnrollmentByUserAndCourseSpec : BaseSpecification<Enrollment>
    {
        public EnrollmentByUserAndCourseSpec(string userId, int courseId)
            : base(e => e.UserId == userId && e.CourseId == courseId)
        {
        }
    }
}
