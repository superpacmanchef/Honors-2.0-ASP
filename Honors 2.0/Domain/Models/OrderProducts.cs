using System;
using System.Collections.Generic;

namespace Honors_2._0.Domain.Models
{
    public partial class OrderProducts
    {   public OrderProducts() { }
        public OrderProducts(Orders order , string productID , int quantity)
        {
            Order = order;
            ProductId = productID;
            Quantity = quantity;
        }
        public string ProductId { get; set; }
        public string OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
