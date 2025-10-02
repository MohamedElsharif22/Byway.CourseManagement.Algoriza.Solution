using Byway.Domain.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities.Checkout
{
    public class Checkout : BaseEntity
    {
        public string UserId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentTransactionId { get; set; }
        public CheckoutStatus Status { get; set; } = CheckoutStatus.Completed;
        public ICollection<Enrollment> PurchasedCourses { get; set; } = new HashSet<Enrollment>();
    }
}
