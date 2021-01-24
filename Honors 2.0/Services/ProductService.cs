using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> DeleteProduct(string ProductID)
        {
            Products product = this.GetProductByProductID(ProductID).Result;
            return await _productRepository.DeleteProduct(product);
        }

        public async Task<Products> GetProductByProductID(string ProductID)
        {
            return await _productRepository.GetProductbyProductID(ProductID);
        }

        public async Task<IEnumerable<Products>> GetProductPage(int NumberPerPage, int PageNumber, string Catagory)
        {
            if (Catagory != null)
            {
                return await _productRepository.GetProductPageCatagory(NumberPerPage , PageNumber , Catagory);
            }
            else
            {
                return await _productRepository.GetProductPage(NumberPerPage, PageNumber);
            }
        }

        public async Task<int> UpdateNumberOfProductsRemaining(string ProductID, int NumberBought)
        {
            Products product = this.GetProductByProductID(ProductID).Result;
            return await _productRepository.UpdateProductQuantity(product, NumberBought);
        }
    }}


    