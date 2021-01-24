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
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(Honors20Context context) : base(context)
        {
        }

        public async Task<int> CreateReview(Reviews review)
        {
            await _context.Reviews.AddAsync(review);
            try
            {
                return await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Reviews>> GetReviewsByProductID(string ProductID)
        {
            return await _context.Reviews.Where(r => r.ProductId == ProductID).ToListAsync();
        }

        public async Task<IEnumerable<Reviews>> GetReviewsByUserID(string UserID)
        {
            return await _context.Reviews.Where(r => r.UserId == UserID).ToListAsync();
        }
    }
}
