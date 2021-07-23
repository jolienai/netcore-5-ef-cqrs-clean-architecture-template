using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanArchitectureTemplate.Application.Cqrs.Commands;
using CleanArchitectureTemplate.Application.Cqrs.Queries;
using CleanArchitectureTemplate.Application.Dtos;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastsController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastsController(ILogger<WeatherForecastsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new WeatherForecastQuery());
            return Ok(new { data = response });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddForecast(AddWeatherForecastDto forecastDto, CancellationToken cancelationToken)
        {
            var response = await _mediator.Send(new AddWeatherForecast(forecastDto), cancelationToken);
            return Created("",new { data = response });
        }
    }
}
