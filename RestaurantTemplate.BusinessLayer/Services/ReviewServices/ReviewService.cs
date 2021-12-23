using MongoDB.Driver;
using RestaurantTemplate.DataAccessLayer;
using RestaurantTemplate.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.BusinessLayer.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly string _collection = "review";
        private readonly IMongoCollection<Review> _review;

        public ReviewService(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _review = database.GetCollection<Review>(this._collection);
        }

        public Task<List<Review>> GetAllAsync()
        {
            return _review.Find(rev => true).ToListAsync();
        }

        public async Task<Review> CreateAsync(Review review)
        {
            await _review.InsertOneAsync(review);
            return review;
        }

        public async Task<Review> UpdateAsync(Review review)
        {
            await _review.ReplaceOneAsync(rev => rev.Id == review.Id, review);
            return review;
        }

        public async Task DeleteAsync(string Id)
        {
            await _review.DeleteOneAsync(rev => rev.Id == Id);
        }
    }
}
