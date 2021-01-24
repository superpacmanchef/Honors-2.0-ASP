using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Persistance.Contexts;
using HonorsTest2.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Persistance.Repositories
{
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {

        public OrdersRepository(Honors20Context context) : base(context)
        {
        }

        public async Task<int> CreateOrder(Orders order)
        {
            _context.Orders.Add(order);
            try
            {
                return await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                return 0;
            }

        }

        public async Task<Orders> GetOrderByOrderID(string OrderID)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == OrderID);
        }

        public async Task<IEnumerable<Orders>> GetOrdersIDByUserID(string UserID)
        {
            return await _context.Orders.Where(o => o.UserId == UserID).ToListAsync();
        }
    }
}
