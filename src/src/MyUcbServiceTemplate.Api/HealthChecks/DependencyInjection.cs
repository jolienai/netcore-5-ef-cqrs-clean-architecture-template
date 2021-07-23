using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Api.HealthChecks
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHealthCHecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecksUI()
                .AddInMemoryStorage();

            services.AddHealthChecks()
                    .AddSqlServer(configuration.GetValue<string>("DATABASE_CONNECTION"), name: "sqlserver");

            return services;
        }
    }
}
