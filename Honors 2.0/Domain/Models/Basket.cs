using System;
using System.Collections.Generic;

namespace Honors_2._0.Domain.Models
{
    public partial class Basket
    {   
        public Basket() { }
        public Basket(Users user)
        {
            User = user;
            BasketId = Guid.NewGuid().ToString();
            BasketProducts = new HashSet<BasketProducts>();
        }

        public string BasketId { get; set; }
        public string UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<BasketProducts> BasketProducts { get; set; }
    }
}
