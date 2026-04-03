using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.DTOs
{
    public record LoginDto(string Username, string Password);
    public record AddCartDto(Guid ProductId, int Quantity);
    public record CheckoutDto(string Address);
}
