using System.ComponentModel.DataAnnotations;

namespace Byway.Application.DTOs.Cart
{
    public record CartItemRequest
    {
        [Required]
        public int CourseId { get; set; }
    }
}
