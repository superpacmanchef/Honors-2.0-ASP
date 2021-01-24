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
    public class OrderProductRepository : BaseRepository , IOrderProductsRepository
    {

        public OrderProductRepository(Honors20Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Products>> GetProductsByOrderID(string OrderID)
        {
            return await _context.OrderProducts.Where(op => op.OrderId == OrderID).Select(op => op.Product).ToListAsync();
        }

        public async Task<int> InsertProductIntoOrder(OrderProducts orderProducts)
        {
            await _context.OrderProducts.AddAsync(orderProducts);
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return 0;
            }
            throw new NotImplementedException();
        }
    }
}
