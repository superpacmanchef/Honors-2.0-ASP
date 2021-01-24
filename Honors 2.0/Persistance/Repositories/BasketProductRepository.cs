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
    public class BasketProductRepository : BaseRepository, IBasketProductRepository
    {
        public BasketProductRepository(Honors20Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Products>> GetProductsByBasketID(string BasketID)
        {
            return await _context.BasketProducts.Where(bp => bp.BasketId == BasketID).Select(bp => bp.Product).ToListAsync();
        }

        public async Task<BasketProducts> GetProductFromBasket(string BasketID , string ProductID)
        {
            return await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.BasketId == BasketID && bp.ProductId == ProductID);
        }

        public async Task<IEnumerable<BasketProducts>> GetBasketProductsByBasketID(string BasketID)
        {
            return await _context.BasketProducts.Where(bp => bp.BasketId == BasketID).ToListAsync();
        }

        public async Task<int> AddProductToBasket(BasketProducts basketProduct)
        {
             _context.BasketProducts.Add(basketProduct);
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return 0;            
            }
        }

        public async Task<int> RemoveProductFromBasket(BasketProducts basketProducts)
        {
            _context.BasketProducts.Remove(basketProducts);
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public async Task<int> RemoveAllProductsFromBasket(IEnumerable<BasketProducts> basketProducts)
        {
            BasketProducts[] productsArray = basketProducts.ToArray();
            for(int i = 0; i < productsArray.Length; i++)
            {
                _context.BasketProducts.Remove(productsArray[i]);
            }
            try
            {
               return await _context.SaveChangesAsync();
            }
            catch
            {
                return 0;
            }

            
            
        }
    }
}
