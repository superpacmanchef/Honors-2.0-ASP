using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Repository
{
    public interface IOrderProductsRepository
    {
        public Task<IEnumerable<OrderProducts>> GetProductsByOrderID(string BasketID);
        public Task<int> InsertProductIntoOrder(OrderProducts orderProducts);

    }
}
