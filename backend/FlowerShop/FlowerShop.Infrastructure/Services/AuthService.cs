using FlowerShop.Application.DTOs;
using FlowerShop.Application.Interfaces;
using FlowerShop.Domain.Entities;
using FlowerShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Login(LoginDto dto)
        {
            var user = await _context.Users
               .Include(u => u.Role)
               .FirstOrDefaultAsync(x => x.Username == dto.Username);

            return user;
        }
    }
}
