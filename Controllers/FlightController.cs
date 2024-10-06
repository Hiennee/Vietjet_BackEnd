using Microsoft.AspNetCore.Mvc;
using Vietjet_BackEnd.Services;

namespace Vietjet_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : Controller
    {
        private readonly FlightService _service;
        public FlightController(FlightService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var result = await _service.GetFlights();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight([FromRoute(Name = "id")] string id)
        {
            var result = await _service.GetFlight(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("IsConfirmed/{id}")]
        public async Task<bool> IsFlightConfirmed([FromRoute(Name = "id")] string id)
        {
            return await _service.IsFlightConfirmed(id);
        }
        [HttpGet("Documents/{id}")]
        public async Task<IActionResult> GetDocumentsOfFlight([FromRoute(Name = "id")] string id)
        {
            var result = await _service.GetDocumentsOfFlight(id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("Compartments/{id}")]
        public async Task<IActionResult> GetCompartmentsOfFlight([FromRoute(Name = "id")] string id)
        {
            var result = await _service.GetCompartmentsOfFlight(id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("Documents/{id}")]
        public async Task<IActionResult> GetAircraftOfFlight([FromRoute(Name = "id")] string id)
        {
            var result = await _service.GetAircraftOfFlight(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
