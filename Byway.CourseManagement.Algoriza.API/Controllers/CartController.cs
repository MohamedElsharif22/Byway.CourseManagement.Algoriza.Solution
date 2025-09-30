using Byway.Application.Contracts;
using Byway.Application.DTOs.Cart;
using Byway.Application.Mapping;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.Domain.Entities.Cart;
using Byway.Domain.Repositoies.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    public class CartController(ICartRepository cartRepository, ICourseService courseService) : BaseApiController
    {
        private readonly ICartRepository _cartRepo = cartRepository;
        private readonly ICourseService _courseService = courseService;

        [HttpGet]
        [EndpointSummary("Get Cart by Id")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Cart>> GetCart(string cartId)
        {
            var cart = await _cartRepo.GetCartAsync(cartId);
            if (cart is null)
                return StatusCode(StatusCodes.Status503ServiceUnavailable, 
                                  new ApiResponse(StatusCodes.Status503ServiceUnavailable, "Error occured while retrieving the cart!"));
            return Ok(cart);
        }

        [HttpPost]
        [EndpointSummary("Update Cart")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Cart>> UpdateCart(CartRequest cartRequest)
        {
            var cart = await _cartRepo.GetCartAsync(cartRequest.CartId);
            if (cart is null)
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  new ApiResponse(StatusCodes.Status503ServiceUnavailable, "Error occured while Finding the cart!"));


            foreach (var item in cartRequest.Items)
            {
                var course = await _courseService.GetCourseByIdAsync(item.CourseId);
                if (course is null)
                    continue;

                cart.Items.Add(course.ToCartItem());
            }

            var updatedCart = await _cartRepo.UpdateCartAsync(cart);
            if (updatedCart is null)
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  new ApiResponse(StatusCodes.Status503ServiceUnavailable, "Error occured while updating the cart!"));
            return Ok(updatedCart);
        }

        [HttpDelete]
        [EndpointSummary("Delete Cart")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteCart(string cartId)
        {
            var result = await _cartRepo.DeleteCartAsync(cartId);
            if (!result)
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  new ApiResponse(StatusCodes.Status503ServiceUnavailable, "Error occured while deleting the cart!"));
            return Ok(new ApiResponse(200, "Cart Deleted Successfuly!"));
        }


    }
}
