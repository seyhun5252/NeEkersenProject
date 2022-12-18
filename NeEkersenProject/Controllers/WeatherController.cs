using BusinesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NeEkersenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("weatherList")]
        public IActionResult GetCompanyList(string city)
        {
            var result = _weatherService.GetList(city);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
