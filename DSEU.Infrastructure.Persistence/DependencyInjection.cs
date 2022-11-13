using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Interfaces;

namespace WebApp.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<AppDbContext>());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

           
            var svcProvider = services.BuildServiceProvider();           

            return services;
        }
    }
}