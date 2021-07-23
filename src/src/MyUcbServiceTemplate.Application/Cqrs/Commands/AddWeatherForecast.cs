using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using CleanArchitectureTemplate.Application.Dtos;
using CleanArchitectureTemplate.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Cqrs.Commands
{
    public class AddWeatherForecast : IRequest<int>
    {
        public AddWeatherForecastDto ForecastDto { get; }

        public AddWeatherForecast(AddWeatherForecastDto forecastDto)
        {
            ForecastDto = forecastDto;
        }
    }

    public class AddWeatherForecastHandler : IRequestHandler<AddWeatherForecast, int>
    {
        private readonly ICleanArchitectureTemplateDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AddWeatherForecastHandler> _logger;

        public AddWeatherForecastHandler(ICleanArchitectureTemplateDbContext context, IMapper mapper, ILogger<AddWeatherForecastHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddWeatherForecast request, CancellationToken cancellationToken)
        {
            var forecast = _mapper.Map<Domain.Entities.WeatherForecast>(request.ForecastDto);

            var result = await _context.Set<Domain.Entities.WeatherForecast>().AddAsync(forecast, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
    }
}
