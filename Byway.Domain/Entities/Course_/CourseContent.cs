using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities.Course_
{
    public class CourseContent : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        public int LecturesCount { get; set; }
        [Required]
        [MinLength(1)]
        public int DurationInHours { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
