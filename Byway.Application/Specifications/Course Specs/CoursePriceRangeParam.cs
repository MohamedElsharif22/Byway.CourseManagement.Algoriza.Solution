using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Byway.Application.Specifications.Course_Specs
{
    public class CoursePriceRangeParam
    {
        [Description("Minimum price filter (default = 0)")]
        [Range(0, int.MaxValue, ErrorMessage = "Min price must be greater than or equal to 0")]
        public int Min { get; set; }
        [Description("Maximum price filter (default = 1000)")]
        [Range(0, int.MaxValue, ErrorMessage = "Max price must be greater than or equal to 0")]
        public int Max { get; set; } = 1000;
    }
}