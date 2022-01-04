using MongoDB.Driver;
using RestaurantTemplate.DataAccessLayer;
using RestaurantTemplate.DataAccessLayer.Entities;
using RestaurantTemplate.Shared;
using RestaurantTemplate.Shared.RequestModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.BusinessLayer.Services.MenuServices
{
    public class MenuServices : IMenuServices
    {
        private readonly string _collection = "menu";
        private readonly IMongoCollection<Menu> _menu;

        public MenuServices(IDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _menu = database.GetCollection<Menu>(this._collection);
        }

        public async Task<Dictionary<string, List<Menu>>> GetAsync()
        {
            var resultFromDb = await (await _menu.FindAsync(m => true)).ToListAsync();

            Dictionary<string, List<Menu>> result = new();

            foreach (var menu in resultFromDb)
            {
                if (result.ContainsKey(menu.Category))
                {
                    result[menu.Category].Add(menu);
                }
                else
                {
                    result.Add(menu.Category, new List<Menu>());
                    result[menu.Category].Add(menu);
                }
            }

            return result;
        }

        public async Task<Response> CreateAsync(MenuRequest menuRequest)
        {
            var menu = new Menu()
            {
                Id = null,
                Name = menuRequest.Name,
                Category = menuRequest.Category,
                Ingredients = menuRequest.Ingredients,
                Allergens = menuRequest.Allergens,
                Price = menuRequest.Price
            };

            await _menu.InsertOneAsync(menu);
            return new Response()
            {
                StatusCode = 200,
                Error = ""
            };
        }

        public async Task<Response> UpdateAsync(Menu menu)
        {
            if (string.IsNullOrEmpty(menu.Id) || menu.Id.Trim().Length != 24)
            {
                return new Response()
                {
                    StatusCode = 400,
                    Error = "Id is not valid"
                };
            }

            if (!(await _menu.FindAsync(m => m.Id == menu.Id)).Any<Menu>())
            {
                return new Response()
                {
                    StatusCode = 404,
                    Error = "Id not found"
                };
            }

            await _menu.ReplaceOneAsync(e => e.Id == menu.Id, menu);

            return new Response()
            {
                StatusCode = 200,
                Error = ""
            };
        }

        public async Task<Response> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Trim().Length != 24)
            {
                return new Response()
                {
                    StatusCode = 400,
                    Error = "Id is not valid"
                };
            }

            var result = await _menu.DeleteOneAsync(id);
            if (result.DeletedCount == 0)
            {
                return new Response()
                {
                    StatusCode = 404,
                    Error = "Id not found"
                };
            }

            return new Response()
            {
                StatusCode = 200,
                Error = ""
            };
        }

    }
}
