using RestaurantTemplate.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.BusinessLayer.Services.ReviewServices
{
    public interface IReviewService
    {
        public Task<List<Review>> GetAllAsync();

        public Task<Review> CreateAsync(Review review);

        public Task<Review> UpdateAsync(string id, Review reviewIn);

        public Task DeleteAsync(Review review);
    }
}
