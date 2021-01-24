using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Honors_2._0.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public ReviewController(IReviewService reviewService , IUserService userService , IProductService productService)
        {
            _reviewService = reviewService;
            _userService = userService;
            _productService = productService;
        }


        [HttpPost]
        [Route("product")]
        public async Task<IEnumerable<Reviews>> GetReviewsByProductID([FromForm]string ProductID)
        {
            return await _reviewService.GetReviewsByProductID(ProductID);
        }

        [HttpPost]
        [Route("user")]
        public async Task<IEnumerable<Reviews>> GetReviewsByUserID()
        {
            string UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {
                return await _reviewService.GetReviewsByUserID(UserID);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<int> CreateReview( [FromForm] string ProductID , [FromForm] string Review)
        {
            string UserID = HttpContext.Session.GetString("UserID");
            if (UserID != null)
            {
                Users user = await _userService.GetUserByUserID(UserID);
                Products product = await _productService.GetProductByProductID(ProductID);
                return await _reviewService.CreateReview(user, product, Review);
            }
            else
            {
                return 0;
            }

        }
    }
}
