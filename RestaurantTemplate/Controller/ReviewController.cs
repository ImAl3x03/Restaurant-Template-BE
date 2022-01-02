using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTemplate.BusinessLayer.Services.ReviewServices;
using RestaurantTemplate.DataAccessLayer.Entities;
using RestaurantTemplate.Shared;
using RestaurantTemplate.Shared.RequestModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Review>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<List<Review>>> Get()
        {
            var result = await _reviewService.GetAllAsync();

            return result == null || result.Count == 0 ? NotFound("There aren't reviews") : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<Response>> Create(ReviewRequest reviewReq)
        {
            var response = await _reviewService.CreateAsync(reviewReq);

            return StatusCode(response.StatusCode, response.Error);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<Response>> Update(Review review)
        {
            var response = await _reviewService.UpdateAsync(review);

            return StatusCode(response.StatusCode, response.Error);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<Response>> Delete(string id)
        {
            var response = await _reviewService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response.Error);
        }
    }
}
