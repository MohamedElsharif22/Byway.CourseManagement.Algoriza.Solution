using Byway.Application.Specifications.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Specifications.Course_Specs
{
    public class CourseSpecParams
    {
        private const int MaxPageSize = 30;
        private int pageSize = MaxPageSize;

        [Description("Number of results per page (default = 30, max = 30)")]
        [Range(1, 30, ErrorMessage = "Page size must be between 1 and 30")]
        public int PageSize
        {
            get { return pageSize; }
            set => pageSize = value > MaxPageSize || value <= 0 ? MaxPageSize : value;
        }

        [Description("Filter courses by category ID")]
        public List<int>? Categories { get; set; }

        [Description("Filter courses by instructor ID")]
        public int? InstructorId { get; set; }

        [Description("Search term to filter courses by title")]
        [StringLength(100, ErrorMessage = "Search term cannot exceed 100 characters")]
        public string? Search { get; set; }

        [Description("Sorting option (1 = PriceAsc, 2 = PriceDesc, 3 = RatingAsc, 4 = RatingDesc, 5 = Newest, 6 = Oldest)")]
        [Range(1, 6, ErrorMessage = "Sort value must be between 1 and 6")]
        public byte? Sort { get; set; }

        [Description("Price range filter (default = MinPrice: 0, MaxPrice: 1000)")]
        public CoursePriceRangeParam? PriceRange { get; set; }

        [Description("Range of lectures filter (default = MinLectures: 0, MaxLectures: 1000)")]
        public LecturesRangeSpecParam? RangeOfLectures { get; set; }

        [Description("Current page index (default = 1)")]
        [Range(1, int.MaxValue, ErrorMessage = "Page index must be greater than 0")]
        public int PageIndex { get; set; } = 1;
    }
}
