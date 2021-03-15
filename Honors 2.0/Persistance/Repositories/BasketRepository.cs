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
    public class BasketRepository : BaseRepository, IBasketRepository
    {
        public BasketRepository(Honors20Context context) : base(context)
        {
        }
        public async Task<int> CreateBasket(Users User)
        {
            Basket Basket = new Basket(User);
            await _context.Basket.AddAsync(Basket);
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            };

        }
        public async Task<Basket> GetBasketByUserID(string UserID) 
        {
            return await _context.Basket.Include(b => b.BasketProducts).AsNoTracking().FirstOrDefaultAsync(b => b.UserId == UserID);
        }

        public async Task<string> GetBasketIDByUserID(string UserID)
        {
            Basket basket = await _context.Basket.FirstOrDefaultAsync(b => b.UserId == UserID);
            return basket.BasketId;

        }
    }
}
 