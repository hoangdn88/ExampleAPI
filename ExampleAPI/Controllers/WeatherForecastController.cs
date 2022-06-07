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
        private string connectString = "mongodb://localhost:27077,65.0.115.163:27717,65.0.115.163:27018?connect=replicaSet";

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello")]
        public async Task<IActionResult> Hello(CancellationToken cancellationToken)
        {
            var setting = new MongoClientSettings
            {
                Servers = new[]
                       {
                          new MongoServerAddress("localhost", 27077),
                          new MongoServerAddress("65.0.115.163", 27717),
                          new MongoServerAddress("65.0.115.163", 27018)
                       },
                ConnectionMode = ConnectionMode.Automatic,
                ReplicaSetName = "rs0",
                WriteConcern = new WriteConcern(WriteConcern.WValue.Parse("3"), wTimeout: TimeSpan.Parse("10"))
            };

            MongoClient client = new MongoClient(connectString);
            var db = client.GetDatabase("FireManufacture");
            var collection = db.GetCollection<DeviceTypeInfo>("DeviceTypeInfo");

            var results = await collection.Find(x => x.DeleteFlag == false).ToListAsync();

            return Ok(results);
        }
    }
}