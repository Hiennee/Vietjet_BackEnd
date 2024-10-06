using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vietjet_BackEnd.DTO;
using Vietjet_BackEnd.Models;
using Vietjet_BackEnd.Services;

namespace Vietjet_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AircraftController : Controller
    {
        private readonly AircraftService _service;
        public AircraftController(AircraftService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAircrafts()
        {
            var result = await _service.GetAircrafts();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAircraft([FromRoute(Name = "id")] string id)
        {
            var result = await _service.GetAircraft(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
