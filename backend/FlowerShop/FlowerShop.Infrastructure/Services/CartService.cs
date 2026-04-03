using FlowerShop.Application.Interfaces;
using FlowerShop.Domain.Entities;
using FlowerShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> Get(Guid userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        public async Task Add(Guid userId, Guid productId, int qty)
        {
            var cart = await Get(userId);

            var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
                item.Quantity += qty;
            else
                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = qty
                });

            await _context.SaveChangesAsync();
        }
    }
}
