using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Specifications.Instructor_Specs
{
    public class InstructorSpecParams
    {
        [Description("Search by Name")]
        public string? Search { get; set; }
        [Description("Page Size, Default = (20)")]
        public int PageSize { get; set; } = 20;
        [Description("Page Index, Default = (1)")]
        public int PageIndex { get; set;} = 1;

    }
}
