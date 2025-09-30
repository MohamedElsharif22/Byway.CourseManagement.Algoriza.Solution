using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.Cart
{
    public class CartRequest
    {
        [Required]
        public string CartId { get; set; }
        [Required]
        [MinLength(1,ErrorMessage = "Cart Must contain at least one item")]
        public List<CartItemRequest> Items { get; set; } = new List<CartItemRequest>();
    }
}
