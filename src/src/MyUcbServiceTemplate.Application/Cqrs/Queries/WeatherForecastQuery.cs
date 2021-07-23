using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CleanArchitectureTemplate.Application.Dtos;
using CleanArchitectureTemplate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Cqrs.Queries
{
    public class WeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
    {
    }


    public class WeatherForecastQueryHandler : IRequestHandler<WeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        private readonly ICleanArchitectureTemplateDbContext _context;
        private readonly ILogger<WeatherForecastQueryHandler> _logger;

        public WeatherForecastQueryHandler(ICleanArchitectureTemplateDbContext context, ILogger<WeatherForecastQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<WeatherForecast>> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            var rng = new Random();

            var query = _context.Set<Domain.Entities.WeatherForecast>().AsQueryable();

            return from f in await query.ToListAsync(cancellationToken)
                   select new WeatherForecast()
                   {
                       Date = f.Created,
                       TemperatureC = f.TemperatureC,
                       Summary = Summaries[rng.Next(Summaries.Length)]
                   };
        }
    }
}
