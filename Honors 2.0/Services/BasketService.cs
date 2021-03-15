using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Domain.Services;

namespace Honors_2._0.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketProductRepository _basketProductsRepository;

        public BasketService(IBasketRepository basketRepository , IBasketProductRepository basketProductRepository)
        {
            _basketRepository = basketRepository;
            _basketProductsRepository = basketProductRepository;
        }

        public async Task<int> AddProductToBasket(string UserID , string ProductID , int Quantity)
        {
            string basketID = await _basketRepository.GetBasketIDByUserID(UserID);
            BasketProducts basketProducts = new BasketProducts(basketID, ProductID, Quantity);
            return await _basketProductsRepository.AddProductToBasket(basketProducts);

        }

        public async Task<IEnumerable<Products>> GetBasketProductsProductsByUserID(string UserID)
        {
            string basketID = await _basketRepository.GetBasketIDByUserID(UserID);
            return await _basketProductsRepository.GetProductsByBasketID(basketID);
        }
        
        public async Task<IEnumerable<BasketProducts>> GetBasketProductsByUserID(string UserID)
        {
            string basketID = await _basketRepository.GetBasketIDByUserID(UserID);
            return await _basketProductsRepository.GetBasketProductsByBasketID(basketID);

        }

        public async Task<Basket> GetBasketByUserID(string UserID)
        {
            return await _basketRepository.GetBasketByUserID(UserID);
        }

        public async Task<int> RemoveAllProductsFromBasket(string UserID)
        {
            IEnumerable<BasketProducts> basketProducts =  await GetBasketProductsByUserID(UserID);
            return await _basketProductsRepository.RemoveAllProductsFromBasket(basketProducts);
        }

        public async Task<int> RemoveProductFromBasket(string UserID, string ProductID)
        {
                string basketID = await _basketRepository.GetBasketIDByUserID(UserID);
                BasketProducts basketProduct = await _basketProductsRepository.GetProductFromBasket(basketID, ProductID);
                return await _basketProductsRepository.RemoveProductFromBasket(basketProduct);
    
        }
    }
}
