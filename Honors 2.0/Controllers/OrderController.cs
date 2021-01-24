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
        public async Task<IEnumerable<Products>> GetOrderByOrderID([FromForm] string OrderID)
        {
            return await _orderService.GetUserOrderProductsByOrderID(OrderID);
        }

        [HttpPost]
        [Route("basket")]
        public async Task<int> OrderBasket()
        {
            string UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {
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
            else
            {
                return 0;
            }
        }

    }
}
