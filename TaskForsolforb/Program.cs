using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaskForsolforb.Data;

namespace TaskForsolforb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            await MigrateDatabases(scope);
             await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((context, builder) =>
               {
                   builder.AddEnvironmentVariables();

                   
               })
               .ConfigureServices((builder, services) =>
               {
                   
                   services.AddScoped<DatabaseMigrator>();
                  
                  
               })
             
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });

        private static async Task MigrateDatabases(IServiceScope scope)
        {
            var databaseMigrator = scope.ServiceProvider.GetRequiredService<DatabaseMigrator>();
            await databaseMigrator.MigrateAsync();
        }
    }
}
