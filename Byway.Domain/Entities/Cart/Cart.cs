using Byway.Domain.Repositoies.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Entities.Cart
{
    public class Cart
    {
        public string Id { get; set; }
        public const decimal Tax = ICartRepository.TaxRate;
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public Cart(string id)
        {
            Id = id;
        }
        public decimal TotalPriceBeforeTax => Items.Sum(item => item.Price);
        public decimal TotalTax => TotalPriceBeforeTax * Tax;
        public decimal TotalPrice => TotalPriceBeforeTax + TotalTax;
    }
}
