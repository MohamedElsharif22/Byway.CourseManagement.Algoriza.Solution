using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Specifications.Enums
{
    public enum SortingEnum : byte
    {
        [Description("Sort by price, ascending")]
        PriceAsc = 1,

        [Description("Sort by price, descending")]
        PriceDesc,

        [Description("Sort by rating, ascending")]
        RatingAsc,

        [Description("Sort by rating, descending")]
        RatingDesc,

        [Description("Newest courses first")]
        Newest,

        [Description("Oldest courses first")]
        Oldest 
    }

}
