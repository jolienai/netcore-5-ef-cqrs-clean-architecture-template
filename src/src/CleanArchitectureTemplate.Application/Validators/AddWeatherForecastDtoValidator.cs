using FluentValidation;
using CleanArchitectureTemplate.Application.Dtos;

namespace CleanArchitectureTemplate.Application.Validators
{
    public class AddWeatherForecastDtoValidator : AbstractValidator<AddWeatherForecastDto>
    {
        public AddWeatherForecastDtoValidator()
        {
            RuleFor(x => x.Date).NotNull().NotEmpty();
            RuleFor(x => x.TemperatureC).NotNull();
        }
    }
}
