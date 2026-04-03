using FlowerShop.Application.Interfaces;
using FlowerShop.Domain.Entities;
using FlowerShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
