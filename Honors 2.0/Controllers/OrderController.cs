
using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Honors_2._0.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IUserService _userservice;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService , IBasketService basketService, IUserService userservice , IProductService productService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _userservice = userservice;
            _productService = productService;
        }

        [HttpPost]
        public async Task<List<IEnumerable<OrderProducts>>> GetOrderByOrderID()
        {
            string UserID = HttpContext.Session.GetString("UserID");
            if(UserID != null)
            {
                IEnumerable<Orders> orders = await _orderService.GetUserOrderIds(UserID);
                List<IEnumerable<OrderProducts>> orderProducts = new List<IEnumerable<OrderProducts>>();
                foreach(var order in orders)
                {
                    var r = await _orderService.GetUserOrderProductsByOrderID(order.OrderId);
                    orderProducts.Add(r);
                }
                return orderProducts;
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Route("basket")]
        public async Task<int> OrderBasket()
        {
            string UserID = HttpContext.Session.GetString("UserID");
            try
            {
                if (UserID == null)
                {
                    throw new UnauthorizedAccessException();
                }
                Users user = await _userservice.GetUserByUserID(UserID);
                IEnumerable<BasketProducts> basketProducts = await _basketService.GetBasketProductsByUserID(UserID);
                BasketProducts[] productsArray = basketProducts.ToArray();
                await _orderService.OrderBasket(basketProducts, user);
                await _basketService.RemoveAllProductsFromBasket(UserID);
                for (int i = 0; i < productsArray.Length; i++)
                {
                    await _productService.UpdateNumberOfProductsRemaining(productsArray[i].ProductId, productsArray[i].Quantity);
                }
                return 1;
            }
            catch (Exception e)
            {
                HttpContext.Response.StatusCode = 401;
                HttpContext.Response.WriteAsync(e.Message.ToString()).Wait();
                return 0;
            }
        }

    }
}
