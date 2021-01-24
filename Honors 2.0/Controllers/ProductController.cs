using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase 
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("{productId}")]
        public async Task<Products> GetProductByProductIDAsync(string productId)
        {
            return await _productService.GetProductByProductID(productId);
        }

        [HttpGet("page")]
        public async Task<IEnumerable<Products>> GetProductsPage([FromQuery]int NumberPerPage , [FromQuery]int PageNumber , [FromQuery]string Catagory)
        {
            return await _productService.GetProductPage(NumberPerPage ,PageNumber , Catagory);
        }

        [HttpPut]
        public async Task<int> UpdateProductsRemaining([FromForm] string productId, [FromForm]int quantity)
        {
            return await _productService.UpdateNumberOfProductsRemaining(productId, quantity); 
        }

        [HttpDelete]
        public async Task<int> DeleteProduct([FromForm] string ProductId)
        {
            return await _productService.DeleteProduct(ProductId);
        }
    }
}
