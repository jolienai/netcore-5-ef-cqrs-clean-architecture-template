using System;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class WeatherForecast : BaseEntity
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
    }
}
