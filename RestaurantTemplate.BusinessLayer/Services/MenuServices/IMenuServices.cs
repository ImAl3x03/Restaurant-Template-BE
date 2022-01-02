using RestaurantTemplate.DataAccessLayer.Entities;
using RestaurantTemplate.Shared;
using RestaurantTemplate.Shared.RequestModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.BusinessLayer.Services.MenuServices
{
    public interface IMenuServices
    {
        public Task<Dictionary<string, List<Menu>>> GetAsync();

        public Task<Response> CreateAsync(MenuRequest menuRequest);

        public Task<Response> UpdateAsync(Menu menu);

        public Task<Response> DeleteAsync(string id);
    }
}
