using Byway.Domain.Entities.Checkout;
using Byway.Domain.Entities.enums;
using Byway.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities.Course_
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string CoverPictureUrl { get; set; }
        public CourseLevels Level { get; set; } = CourseLevels.Beginner;
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<CourseContent> Contents { get; set; } = new HashSet<CourseContent>();
    }
}
