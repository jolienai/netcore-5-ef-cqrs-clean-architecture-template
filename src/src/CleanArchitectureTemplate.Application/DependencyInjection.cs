using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System;
using MediatR;

namespace CleanArchitectureTemplate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("CleanArchitectureTemplate.Application");
            services.AddMediatR(assembly);

            services.AddMvc()
               .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(assembly));

            services.AddAutoMapper(assembly);

            return services;

        }
    }
}
