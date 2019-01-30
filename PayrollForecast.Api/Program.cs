using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayrollForecast.Api.Services;
using System;

namespace PayrollForecast.Api
{
    public class Program
    {
        private const string _migrateSeedErrorMsg = "An error occurred with migrating or seeding the DB.";

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    var env = scope.ServiceProvider.GetRequiredService<IHostingEnvironment>();
                    context.Database.Migrate();
                    if (!env.IsProduction())
                        context.EnsureSeedDataForContext();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, _migrateSeedErrorMsg);
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
