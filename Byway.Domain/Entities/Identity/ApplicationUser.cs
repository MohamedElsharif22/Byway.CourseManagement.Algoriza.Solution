using Byway.Domain.Entities.Checkout;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Bio { get; set; }
        public ICollection<BoughtCourse> EnrolledCourses { get; set; }
    }
}
