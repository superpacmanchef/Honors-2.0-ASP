using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetProductCatagoryPage(int PageNumber , int NumberPerPage , string Catagory);
        Task<IEnumerable<Products>> GetProductPage(int PageNumber, int NumberPerPage);
        Task<Products> GetProductByProductID(string ProductID);
        Task<int> UpdateNumberOfProductsRemaining(string productId, int NumberBought);
        Task<int> DeleteProduct(string ProductID);
    }
}
