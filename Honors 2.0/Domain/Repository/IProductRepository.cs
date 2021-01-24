using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Repository
{
    public interface IProductRepository
    {
        Task<Products> GetProductbyProductID(string ProductID);
        Task<int> InsertProduct(Products product);
        Task<int> UpdateProductQuantity(Products product, int quantity);
        Task<int> DeleteProduct(Products product);
        Task<IEnumerable<Products>> GetProductPage(int NumberPerPage, int PageNumber);
        Task<IEnumerable<Products>> GetProductPageCatagory(int NumberPerPage, int PageNumber, string Catagory);


    }
}
