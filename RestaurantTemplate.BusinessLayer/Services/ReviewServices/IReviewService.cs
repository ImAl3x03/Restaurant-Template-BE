using RestaurantTemplate.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.BusinessLayer.Services.ReviewServices
{
    public interface IReviewService
    {
        public Task<List<Review>> GetAllAsync();

        public Task<Review> CreateAsync(Review review);

        public Task<Review> UpdateAsync(Review review);

        public Task DeleteAsync(string Id);
    }
}
