using MongoDB.Driver;
using RestaurantTemplate.DataAccessLayer;
using RestaurantTemplate.DataAccessLayer.Entities;
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

        public async Task<Dictionary<string, List<Menu>>> Get()
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

        public async Task<string> Create(Menu menu)
        {
            await _menu.InsertOneAsync(menu);
            return "";
        }

        public async Task<string> Update(Menu menu)
        {
            await _menu.ReplaceOneAsync(e => e.Id == menu.Id, menu);

            return "";
        }

        public async Task<string> Delete(string id)
        {
            await _menu.DeleteOneAsync(id);

            return "";
        }

    }
}
