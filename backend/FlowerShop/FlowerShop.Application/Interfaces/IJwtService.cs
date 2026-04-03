using FlowerShop.Domain.Entities;

namespace FlowerShop.Application.Interfaces
{
    public interface IJwtService
    {
        string Generate(User user);
    }
}