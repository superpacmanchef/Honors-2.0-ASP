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

        [HttpGet]
        public async Task<Products> GetProductByProductIDAsync([FromQuery]string productId)
        {
            return await _productService.GetProductByProductID(productId);
        }

        [HttpGet("page-catagory")]
        public async Task<IEnumerable<Products>> GetProductsCatagoryPage([FromQuery]float NumberPerPage , [FromQuery]int PageNumber , [FromQuery]string Catagory)
        {
            int page = (int)Math.Floor(NumberPerPage);
            return await _productService.GetProductCatagoryPage(page ,PageNumber , Catagory);
        }

        [HttpGet("page")]
        public async Task<IEnumerable<Products>> GetProductsyPage([FromQuery] float NumberPerPage, [FromQuery] int PageNumber)
        {
            int page = (int) Math.Floor(NumberPerPage);
            return await _productService.GetProductPage(page, PageNumber);
        }

        [HttpPut]
        public async Task<int> UpdateProductsRemaining([FromForm] string productId, [FromForm]int quantity)
        {
            return await _productService.UpdateNumberOfProductsRemaining(productId, quantity); 
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<int> DeleteProduct([FromForm] string ProductId)
        {
            return await _productService.DeleteProduct(ProductId);
        }
    }
}
