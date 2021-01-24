using System;
using System.Collections.Generic;

namespace Honors_2._0.Domain.Models
{
    public partial class Orders
    {   public Orders() { }
        public Orders(Users user)
        {
            User = user;
            OrderId = Guid.NewGuid().ToString();
            OrderProducts = new HashSet<OrderProducts>();
        }

        public string OrderId { get; set; }
        public string UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
