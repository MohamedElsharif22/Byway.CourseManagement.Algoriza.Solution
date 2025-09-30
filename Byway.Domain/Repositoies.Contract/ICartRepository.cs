using Byway.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Repositoies.Contract
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartAsync(string cartId);
        Task<Cart?> UpdateCartAsync(Cart cart);
        Task<bool>  DeleteCartAsync(string cartId);

    }
}
