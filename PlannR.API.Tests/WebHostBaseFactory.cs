﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlannR.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.API.Tests
{
    public class WebHostBaseFactory<T>: WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<PlannrDbContext>(options =>
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope()){

                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<PlannrDbContext>();

                    dbContext.Database.EnsureCreated();

                    try
                    {
                        DbContextDataBase.SeedMockDbContext(dbContext).Wait();
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception(ex.Message);
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