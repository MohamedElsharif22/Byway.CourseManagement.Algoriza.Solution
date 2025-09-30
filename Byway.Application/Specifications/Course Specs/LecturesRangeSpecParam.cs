using System.ComponentModel;

namespace Byway.Application.Specifications.Course_Specs
{
    public class LecturesRangeSpecParam
    {
        [Description("Minimum number of lectures filter (default = 0)")]
        public int Min { get; set; } = 0;
        [Description("Maximum number of lectures filter (default = 1000)")]
        public int Max { get; set; } = 1000;
    }
}