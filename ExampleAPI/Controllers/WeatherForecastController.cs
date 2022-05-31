using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers
{
    [ApiController]
    [Route("api")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello")]
        public async Task<IActionResult> Hello(CancellationToken cancellationToken)
        {
            return Ok("Xin chào API");
        }
    }
}