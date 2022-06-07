namespace ExampleAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class DeviceTypeInfo
    {
        public string Id { set; get; } // Id
        public bool DeleteFlag { set; get; }
        public string DeviceTypeCode { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
    }
}