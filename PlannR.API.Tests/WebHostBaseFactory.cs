using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlannR.Persistence;
using System;
using System.Net.Http;

namespace PlannR.API.Tests
{
    public class WebHostBaseFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<PlannrDbContext>(options =>
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<PlannrDbContext>();

                    try
                    {
                        DbContextDataBase.SeedMockDbContext(dbContext).Wait();
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }

        public HttpClient CreateNewClient()
        {
            return CreateClient();
        }
    }
}
