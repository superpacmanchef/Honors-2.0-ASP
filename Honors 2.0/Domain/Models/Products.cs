using System;
using System.Collections.Generic;

namespace Honors_2._0.Domain.Models
{
    public partial class Products
    {
        public Products()
        {
            BasketProducts = new HashSet<BasketProducts>();
            OrderProducts = new HashSet<OrderProducts>();
            ProductId = Guid.NewGuid().ToString();
            Reviews = new HashSet<Reviews>();
        }

        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remaining { get; set; }
        public string Catagory { get; set; }

        public virtual ICollection<BasketProducts> BasketProducts { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
