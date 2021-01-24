using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honors_2._0.Domain.Models;

namespace Honors_2._0.Domain.Repository
{
    public interface IOrdersRepository
    {
        Task<Orders> GetOrderByOrderID(string OrderID);

        Task<IEnumerable<Orders>> GetOrdersIDByUserID(string UserID);

        Task<int> CreateOrder(Orders order);
    }
}
