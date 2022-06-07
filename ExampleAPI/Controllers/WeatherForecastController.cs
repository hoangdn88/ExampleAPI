using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ExampleAPI.Controllers
{
    [ApiController]
    [Route("api")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private string connectString = "mongodb://localhost:27077/";

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello")]
        public async Task<IActionResult> Hello(CancellationToken cancellationToken)
        {
            MongoClient client = new MongoClient(connectString);
            var db = client.GetDatabase("FireManufacture");
            var collection = db.GetCollection<DeviceTypeInfo>("DeviceTypeInfo");

            var results = await collection.Find(x => x.DeleteFlag == false).ToListAsync();

            return Ok(results);
        }
    }
}