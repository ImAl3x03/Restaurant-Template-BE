using MongoDB.Driver;
using RestaurantTemplate.DataAccessLayer;
using RestaurantTemplate.DataAccessLayer.Entities;
using RestaurantTemplate.Shared;
using RestaurantTemplate.Shared.RequestModel;
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

        public async Task<List<Review>> GetAllAsync()
        {
            return await (await _review.FindAsync(res => true)).ToListAsync();
        }

        public async Task<Response> CreateAsync(ReviewRequest reviewReq)
        {
            var review = new Review
            {
                Id = null,
                Name = reviewReq.Name,
                Text = reviewReq.Text,
                Star = reviewReq.Star
            };

            await _review.InsertOneAsync(review);
            return new Response
            {
                StatusCode = 200,
                Error = ""
            };
        }

        public async Task<Response> UpdateAsync(Review review)
        {
            if (string.IsNullOrEmpty(review.Id) || review.Id.Trim().Length != 24)
            {
                return new Response
                {
                    StatusCode = 400,
                    Error = "Id is not allowed"
                };
            }

            if (!(await _review.FindAsync(rev => rev.Id == review.Id)).Any<Review>())
            {
                return new Response
                {
                    StatusCode = 404,
                    Error = "Id not found"
                };
            }

            await _review.ReplaceOneAsync(rev => rev.Id == review.Id, review);
            return new Response
            {
                StatusCode = 200,
                Error = ""
            };
        }

        public async Task<Response> DeleteAsync(string Id)
        {
            if (string.IsNullOrEmpty(Id) || Id.Trim().Length != 24)
            {
                return new Response
                {
                    StatusCode = 400,
                    Error = "Id is not allowed"
                };
            }

            var rev = await _review.DeleteOneAsync(rev => rev.Id == Id);

            if (rev.DeletedCount == 0)
            {
                return new Response
                {
                    StatusCode = 404,
                    Error = "Id not found"
                };
            }
            else
            {
                return new Response
                {
                    StatusCode = 200,
                    Error = ""
                };
            }
        }
    }
}
