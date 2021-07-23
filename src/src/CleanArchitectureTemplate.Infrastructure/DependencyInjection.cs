using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureTemplate.Application.Interfaces;
using CleanArchitectureTemplate.Infrastructure.GrpcClient;

namespace CleanArchitectureTemplate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGrpcGreeterClient(this IServiceCollection services, IConfiguration configuration)
        {
            var grpcGreeterSettings = new GrpcGreeterClientSettings();
            configuration.GetSection("GrpcGreeterClientSettings").Bind(grpcGreeterSettings);

            services.AddSingleton(grpcGreeterSettings);

            services.AddScoped<IGrpcGreeterClient, GrpcGreeterClient>();

            return services;
        }
    }
}
