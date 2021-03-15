using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Services
{
    public interface IBasketService
    {
        Task<IEnumerable<Products>> GetBasketProductsProductsByUserID(string UserID);
        Task<int> AddProductToBasket(string UserID , string ProductID , int Quantity);
        Task<int> RemoveProductFromBasket(string ProductID, string UserID);
        Task<int> RemoveAllProductsFromBasket(string UserID);
        Task<Basket> GetBasketByUserID(string UserID);
        Task<IEnumerable<BasketProducts>> GetBasketProductsByUserID(string UserID);
    }
}
