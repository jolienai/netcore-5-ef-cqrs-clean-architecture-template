using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Persistence.Database.Configurations
{
    public class WeatherForecastConfig : IEntityTypeConfiguration<Domain.Entities.WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.TemperatureC)
                .IsRequired();

            builder.Property(x => x.Created)
                .IsRequired();

            builder.Property(x => x.LastModified)
                .IsRequired();

        }
    }
}
