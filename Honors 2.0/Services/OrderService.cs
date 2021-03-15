using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IOrderProductsRepository _orderProductRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrdersRepository ordersRepository, IOrderProductsRepository orderProductsRepository )
        {
            _orderProductRepository = orderProductsRepository;
            _orderRepository = ordersRepository;
        }

        public async Task<int> OrderBasket(IEnumerable<BasketProducts> basketProducts , Users user)
        {
            BasketProducts[] productsArray = basketProducts.ToArray();
            Orders order = new Orders(user);
            await _orderRepository.CreateOrder(order);
            for(int i = 0; i < productsArray.Length; i++)
            {
                OrderProducts orderProduct = new OrderProducts(order , productsArray[i].ProductId , productsArray[i].Quantity);
                await _orderProductRepository.InsertProductIntoOrder(orderProduct);
            }

            return 1;
        }

        public Task<IEnumerable<Orders>> GetUserOrderIds(string UserID)
        {
            return _orderRepository.GetOrdersIDByUserID(UserID);
        }

        public async Task<IEnumerable<OrderProducts>> GetUserOrderProductsByOrderID(string OrderID)
        {
            return await _orderProductRepository.GetProductsByOrderID(OrderID);
        }
    }
}
