using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid StatusId { get; set; }
        public string DeliveryAddress { get; set; } = default!;

        public List<OrderItem> Items { get; set; } = new();
    }
}
