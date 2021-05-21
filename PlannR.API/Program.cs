using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlannR.Identity.Models;
using PlannR.Identity.Seed;
using System;
using System.Threading.Tasks;

namespace PlannR.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<PlannrUser>>();
                    await CreatedSeededUsers.SeedAsync(userManager);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
