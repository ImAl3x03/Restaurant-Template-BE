using Microsoft.AspNetCore.Mvc;
using RestaurantTemplate.BusinessLayer.Services.ReviewServices;
using RestaurantTemplate.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<List<Review>> Get()
        {
            return await _reviewService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Review>> Create(Review review)
        {
            return await _reviewService.CreateAsync(review);
        }

        [HttpPut]
        public async Task<ActionResult<Review>> Update(Review review)
        {
            return await _reviewService.UpdateAsync(review);
        }

        [HttpDelete]
        public async Task Delete(string Id)
        {
            await _reviewService.DeleteAsync(Id);
        }
    }
}
