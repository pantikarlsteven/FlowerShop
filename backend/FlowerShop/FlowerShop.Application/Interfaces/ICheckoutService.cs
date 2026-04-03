namespace FlowerShop.Application.Interfaces
{
    public interface ICheckoutService
    {
        Task<Guid> Checkout(Guid userId, string address);
    }
}
