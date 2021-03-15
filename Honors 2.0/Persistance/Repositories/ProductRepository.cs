using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Persistance.Contexts;
using HonorsTest2.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Persistance.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {   
        public ProductRepository(Honors20Context context) : base(context) 
        {
        }

        public async Task<int> DeleteProduct(Products product)
        {
            _context.Products.Remove(product);
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public async Task<Products> GetProductbyProductID(string ProductID)
        {
            Products product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == ProductID);
            return product;
        }

        public async Task<IEnumerable<Products>> GetProductPageCatagory(int NumberPerPage, int PageNumber, string Catagory)
        {   

            return await _context.Products.FromSqlRaw("SELECT * from products WHERE catagory = {0}" , Catagory  ).Skip(NumberPerPage * PageNumber).Take(NumberPerPage).ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductPage(int NumberPerPage, int PageNumber)
        {

            return await _context.Products.FromSqlRaw("SELECT * from products").Skip(NumberPerPage * PageNumber).Take(NumberPerPage).ToListAsync();
        }

        public async Task<int> InsertProduct(Products product)
        {
            await _context.Products.AddAsync(product);
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }


        }

        public async Task<int> UpdateProductQuantity(Products product, int quantity)
        {
            int remaining = int.Parse(product.Remaining) - quantity;
            product.Remaining = remaining.ToString();
            return await _context.SaveChangesAsync();

        }
    }
}
