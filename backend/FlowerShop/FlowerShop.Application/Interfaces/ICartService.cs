using FlowerShop.Domain.Entities;

namespace FlowerShop.Application.Interfaces
{
    public interface ICartService
    {
        Task<Cart> Get(Guid userId);
        Task Add(Guid userId, Guid productId, int qty);
    }
}
