using FlowerShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> Roles => Set<UserRole>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Order> Orders => Set<Order>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            builder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(ci => ci.CartId);

            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            var adminRoleId = Guid.NewGuid();
            var customerRoleId = Guid.NewGuid();

            builder.Entity<UserRole>().HasData(
                new UserRole { Id = adminRoleId, Name = "Admin" },
                new UserRole { Id = customerRoleId, Name = "Customer" }
            );

            var adminId = Guid.NewGuid();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    RoleId = adminRoleId
                }
            );

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Red Roses Bouquet",
                    Description = "Classic romantic bouquet",
                    Price = 999,
                    Stock = 50,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tulips Basket",
                    Description = "Colorful tulips",
                    Price = 799,
                    Stock = 30,
                    ImageUrl = ""
                }
            );
        }
    }
}
