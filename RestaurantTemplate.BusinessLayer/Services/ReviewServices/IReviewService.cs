using RestaurantTemplate.DataAccessLayer.Entities;
using RestaurantTemplate.Shared;
using RestaurantTemplate.Shared.RequestModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.BusinessLayer.Services.ReviewServices
{
    public interface IReviewService
    {
        public Task<List<Review>> GetAllAsync();

        public Task<Response> CreateAsync(ReviewRequest reviewReq);

        public Task<Response> UpdateAsync(Review review);

        public Task<Response> DeleteAsync(string Id);
    }
}
