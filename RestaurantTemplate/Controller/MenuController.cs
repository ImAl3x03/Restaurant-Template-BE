using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTemplate.BusinessLayer.Services.MenuServices;
using RestaurantTemplate.DataAccessLayer.Entities;
using RestaurantTemplate.Shared;
using RestaurantTemplate.Shared.RequestModel;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, List<Menu>>))]
        public async Task<Dictionary<string, List<Menu>>> Get()
        {
            var result = await _services.GetAsync();
            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<Response>> AddMenu(MenuRequest menu)
        {
            var response = await _services.CreateAsync(menu);

            return StatusCode(response.StatusCode, response.Error);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<Response>> UpdateMenu(Menu menu)
        {
            var response = await _services.UpdateAsync(menu);

            return StatusCode(response.StatusCode, response.Error);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<Response>> DeleteMenu(string id)
        {
            var response = await _services.DeleteAsync(id);

            return StatusCode(response.StatusCode, response.Error);
        }
    }
}
