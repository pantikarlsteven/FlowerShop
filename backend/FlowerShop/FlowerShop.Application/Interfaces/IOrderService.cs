using FlowerShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> Get();
    }
}
