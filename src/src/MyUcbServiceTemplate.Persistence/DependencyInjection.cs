using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureTemplate.Application.Interfaces;
using CleanArchitectureTemplate.Persistence.Database;
using System;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICleanArchitectureTemplateDbContext>(provider => provider.GetService<CleanArchitectureTemplateDbContext>());

            if (configuration.GetValue<bool>("USE_INMEMORY_DATABASE"))
                return AddInMemoryDatabase(services, configuration);

            return AddDatabase(services, configuration);
        }

        private static IServiceCollection AddDatabase(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CleanArchitectureTemplateDbContext>(options =>
            {
                var connectionString = configuration.GetValue<string>("DATABASE_CONNECTION") ??
                                       throw new ArgumentException(
                                           "Environment variable: DATABASE_CONNECTION is missing");
                options.UseSqlServer(connectionString);
            });

            return services;
        }

        private static IServiceCollection AddInMemoryDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchitectureTemplateDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
            });

            return services;
        }
    }
}
