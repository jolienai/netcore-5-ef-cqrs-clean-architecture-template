using AutoMapper;

namespace CleanArchitectureTemplate.Application.Automapper
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<Dtos.AddWeatherForecastDto, Domain.Entities.WeatherForecast>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.TemperatureC, opt => opt.MapFrom(src => src.TemperatureC))
                .ReverseMap();

        }
    }
}
