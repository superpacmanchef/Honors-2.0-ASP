using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository; 

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<int> CreateReview(Users user, Products product , string reviewString)
        {
            Reviews review = new Reviews(user, product, reviewString);
            return await _reviewRepository.CreateReview(review);
        }

        public async Task<IEnumerable<Reviews>> GetReviewsByProductID(string ProductID)
        {
            return await _reviewRepository.GetReviewsByProductID(ProductID);
        }

        public async Task<IEnumerable<Reviews>> GetReviewsByUserID(string UserID)
        {
            return await _reviewRepository.GetReviewsByUserID(UserID);
        }
    }
}
