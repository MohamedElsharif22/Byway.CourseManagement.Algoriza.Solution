using Byway.Application.Contracts;
using Byway.Application.DTOs.Cart;
using Byway.Application.Mapping;
using Byway.Application.Services;
using Byway.CourseManagement.Algoriza.API.Errors;
using Byway.Domain.Entities.Cart;
using Byway.Domain.Repositoies.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Byway.CourseManagement.Algoriza.API.Controllers
{
    public class CartController(CartService cartService) : BaseApiController
    {
        private readonly CartService _cartService = cartService;

        [HttpGet]
        [EndpointSummary("Get Cart by Id")]
        [EndpointDescription("Get existing cart or creating new one. Expecting GUID ID from the front-end.")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Cart>> GetCart(string id)
        {
            var cart = await _cartService.GetCartAsync(id);
            if (cart is null)
                return StatusCode(StatusCodes.Status503ServiceUnavailable, 
                                  new ApiResponse(StatusCodes.Status503ServiceUnavailable, "Error occured while retrieving the cart!"));
            return Ok(cart);
        }

        [HttpPut]
        [EndpointSummary("Update Cart")]
        [EndpointDescription("Updating existing cart or creating new one. Expecting GUID ID from the front-end.")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Cart>> UpdateCart([FromBody] CartRequest cartRequest)
        {
            var updatedCart = await _cartService.UpdateCartAsync(cartRequest);
            if (updatedCart is null)
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  new ApiResponse(StatusCodes.Status503ServiceUnavailable, "Error occured while updating the cart!"));
            return Ok(updatedCart);
        }

        [HttpDelete]
        [EndpointSummary("Delete Cart")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public ActionResult DeleteCart(string id)
        {
            _cartService.DeleteCart(id);
            return Ok(new ApiResponse(200, "Cart Deleted Successfuly!"));
        }


    }
}
