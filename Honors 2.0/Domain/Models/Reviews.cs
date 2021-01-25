using System;
using System.Collections.Generic;

namespace Honors_2._0.Domain.Models
{
    public partial class Reviews
    {   public Reviews() { }
        public Reviews(Users user , Products product , string reviewString)
        {
            User = user;
            Product = product;
            Review = reviewString;
        }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public string Review { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
