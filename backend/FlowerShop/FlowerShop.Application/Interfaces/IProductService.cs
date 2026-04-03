using FlowerShop.Domain.Entities;

namespace FlowerShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> Get();
    }
}
