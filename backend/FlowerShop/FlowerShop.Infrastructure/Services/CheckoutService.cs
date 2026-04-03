using FlowerShop.Application.Interfaces;
using FlowerShop.Domain.Entities;
using FlowerShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Infrastructure.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly AppDbContext _context;

        public CheckoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Checkout(Guid userId, string address)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstAsync(c => c.UserId == userId);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                DeliveryAddress = address,
                TotalAmount = cart.Items.Sum(i => i.Product.Price * i.Quantity),
                Items = cart.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Product.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cart.Items);

            await _context.SaveChangesAsync();

            return order.Id;
        }
    }
}
