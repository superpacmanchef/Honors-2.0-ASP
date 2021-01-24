using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Repository
{
    public interface IBasketProductRepository
    {
        public Task<IEnumerable<Products>> GetProductsByBasketID(string BasketID);
        public Task<int> AddProductToBasket(BasketProducts basketProducts);
        public Task<BasketProducts> GetProductFromBasket(string BasketID, string ProductID);
        public Task<int> RemoveProductFromBasket(BasketProducts basketProduct);
        public Task<int> RemoveAllProductsFromBasket(IEnumerable<BasketProducts> products);
        public Task<IEnumerable<BasketProducts>> GetBasketProductsByBasketID(string BasketID);
    }
}
