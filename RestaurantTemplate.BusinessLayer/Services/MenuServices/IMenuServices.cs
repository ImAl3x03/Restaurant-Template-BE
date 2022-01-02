using RestaurantTemplate.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.BusinessLayer.Services.MenuServices
{
    public interface IMenuServices
    {
        public Task<Dictionary<string, List<Menu>>> Get();

        public Task<string> Create(Menu menu);

        public Task<string> Update(Menu menu);

        public Task<string> Delete(string id);
    }
}
