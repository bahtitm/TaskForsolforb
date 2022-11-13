using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskForsolforb.Extensions;
using WebApp.Application;
using WebApp.Infrastructure.Persistence;

namespace TaskForsolforb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string AllowedDomainsCorsPolicy = "AllowedDomains";


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDSEUApplicationCore()
                    .AddDSEUPersistence(Configuration);
            services.AddRazorPages();
            services.AddValidatorsFromAssembly(typeof(WebApp.Application.DependencyInjection).Assembly);

            services.AddHttpContextAccessor();

            services.AddCors(ConfigureCors);

            services.AddControllers();



            services.AddSwagger();
            services.AddMemoryCache();

            services.AddSession();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });








        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseSwagger();

            app.UseAuthorization();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapRazorPages();
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
        private void ConfigureCors(CorsOptions options)
        {
            options.AddPolicy(AllowedDomainsCorsPolicy, builder =>
            {
                var tokenValidIssuers = new List<string>();
                
                    tokenValidIssuers.Add("https://localhost:5001");
                tokenValidIssuers.Add("https://localhost:5001/api/Provide/");
                builder.WithOrigins(tokenValidIssuers.ToArray()).AllowAnyMethod().AllowAnyHeader().AllowCredentials().AllowAnyOrigin();
            });
        }
    }
}
