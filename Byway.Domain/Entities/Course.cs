using Byway.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string CoverPictureUrl { get; set; }
        public int LecturesCount { get; set; }
        public int DurationInMinutes { get; set; }
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ApplicationUser> EnrolledUsers { get; set; }
    }
}
