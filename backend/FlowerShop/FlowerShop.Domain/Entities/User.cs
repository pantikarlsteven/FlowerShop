namespace FlowerShop.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public Guid RoleId { get; set; }
        public bool IsActive { get; set; } = true;

        public UserRole Role { get; set; } = default!;
    }
}
