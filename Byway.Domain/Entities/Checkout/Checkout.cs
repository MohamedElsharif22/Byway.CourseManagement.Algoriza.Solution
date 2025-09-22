using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities.Checkout
{
    public class Checkout : BaseEntity
    {
        public int CustomerId { get; set; }
        public ICollection<BoughtCourse> BoughtCourses { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
