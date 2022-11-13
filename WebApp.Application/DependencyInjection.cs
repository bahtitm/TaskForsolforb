using System.Reflection;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Application.Common.Behaviours;

namespace WebApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUApplicationCore(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
