using Microsoft.AspNetCore.Mvc;
using RestaurantTemplate.BusinessLayer.Services.MenuServices;
using RestaurantTemplate.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantTemplate.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _services;

        public MenuController(IMenuServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<Dictionary<string, List<Menu>>> Get()
        {
            var result = await _services.Get();
            return result;
        }

        [HttpPost]
        public async Task<string> AddMenu(Menu menu)
        {
            await _services.Create(menu);

            return "";
        }
    }
}
