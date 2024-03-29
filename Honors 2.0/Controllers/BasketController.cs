﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Honors_2._0.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<BasketProducts>> GetUserBasket()
        {
            string UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {

                return await _basketService.GetBasketProductsByUserID(UserID);
            }
            else
            {
                return null;
            }
       
        }

        [HttpPost]
        [Route("add")]
        public async Task<int> InsertProductToBasket([FromForm] string ProductID , [FromForm] int Quantity)
        {
            string UserID = HttpContext.Session.GetString("UserID");
            try 
            {   if(UserID == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return await _basketService.AddProductToBasket(UserID, ProductID, Quantity);
            }
            catch(UnauthorizedAccessException e)
            {   
                
                HttpContext.Response.StatusCode = 401;
                HttpContext.Response.WriteAsync(e.Message.ToString()).Wait();
                return 0;
            }
        }

        [HttpDelete]
        public async Task<int> RemoveProductFromBasket( [FromForm] string ProductID)
        {
            string UserID = HttpContext.Session.GetString("UserID");
            try
            {   if(UserID == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return await _basketService.RemoveProductFromBasket(UserID, ProductID);
            }
            catch (UnauthorizedAccessException e)
            {
                HttpContext.Response.StatusCode = 401;
                HttpContext.Response.WriteAsync(e.Message.ToString()).Wait();
                return 0;
            }
        }

        [HttpDelete]
        [Route("all")]
        public async Task<int> RemoveAllProductsFromBasket()
        {
            string UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {
                return await _basketService.RemoveAllProductsFromBasket(UserID);
            }
            else
            {
                return 0;
            }
        }
    
    
    }

}
