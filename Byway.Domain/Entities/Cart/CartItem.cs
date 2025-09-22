using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities.Cart
{
    public class CartItem
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CoverImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
