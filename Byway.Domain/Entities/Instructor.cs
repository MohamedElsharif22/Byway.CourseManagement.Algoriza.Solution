using Byway.Domain.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities
{
    public class Instructor : BaseEntity
    {
        public string Name { get; set; }
        public JobTitles JopTitle { get; set; }
        public string? About { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
