using System;
using System.Collections.Generic;

namespace Honors_2._0.Domain.Models
{
    public partial class BasketProducts
    {   
        public BasketProducts() { }
        public BasketProducts(string basketID , string productID , int quantity)
        {
            BasketId = basketID;
            ProductId = productID;
            Quantity = quantity;
        }
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual Products Product { get; set; }
    }
}
