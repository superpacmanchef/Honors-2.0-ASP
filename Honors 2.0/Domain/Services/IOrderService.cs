using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Services
{
    public interface IOrderService
    {
        Task<int> OrderBasket(IEnumerable<BasketProducts> products, Users user);
        Task<IEnumerable<Orders>> GetUserOrderIds(string UserID);
        Task<IEnumerable<OrderProducts>> GetUserOrderProductsByOrderID(string OrderID);

    }
}
