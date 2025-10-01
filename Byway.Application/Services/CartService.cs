using Byway.Application.Contracts;
using Byway.Application.DTOs.Cart;
using Byway.Application.Mapping;
using Byway.Domain.Entities.Cart;
using Byway.Domain.Repositoies.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class CartService(ICartRepository cartRepository,
                             ICourseService courseService)
    {
        private readonly ICartRepository _cartRepo = cartRepository;
        private readonly ICourseService _courseService = courseService;

        public async Task<Cart?> UpdateCartAsync(CartRequest cartRequest)
        {
            var cart = await _cartRepo.GetCartAsync(cartRequest.Id);
            if (cart is null)
                return null;

            foreach (var item in cartRequest.Items)
            {

                var course = await _courseService.GetCourseByIdAsync(item.CourseId);
                if (course is null)
                    continue;

                if (cart.Items.Any(i => i.CourseId == item.CourseId))
                    continue;

                cart.Items.Add(course.ToCartItem());
            }

            return cart;
        }


        public async Task<Cart?> GetCartAsync(string id)
        {
            return await _cartRepo.GetCartAsync(id);
        }
        public void DeleteCart(string id)
        {
            _cartRepo.DeleteCart(id);
        }




    }
}
