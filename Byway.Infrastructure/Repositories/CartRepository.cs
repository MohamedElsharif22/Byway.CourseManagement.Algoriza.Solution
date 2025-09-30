using Byway.Domain.Entities.Cart;
using Byway.Domain.Repositoies.Contract;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure.Repositories
{
    public class CartRepository(IMemoryCache memoryCache) : ICartRepository
    {
        private readonly IMemoryCache _memoryCache = memoryCache;

        public Task<bool> DeleteCartAsync(string cartId)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart?> GetCartAsync(string id)
        {
            return await _memoryCache.GetOrCreateAsync(id, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(5);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(10);
                entry.Priority = CacheItemPriority.Normal;
                return Task.FromResult(new Cart(id));
            });
        }

        public async Task<Cart?> UpdateCartAsync(Cart cart)
        {
            var existingCart = await GetCartAsync(cart.Id);
            if (existingCart is null)
                return null;

            return _memoryCache.Set(cart.Id, cart);
        }
    }
}
