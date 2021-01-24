using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Reviews>> GetReviewsByProductID(string ProductID);
        Task<IEnumerable<Reviews>> GetReviewsByUserID(string UserID);
        Task<int> CreateReview(Users user, Products product , string review);
    }
}
