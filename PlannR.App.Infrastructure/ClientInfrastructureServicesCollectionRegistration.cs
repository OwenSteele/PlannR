using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Plannr.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.Authentication;
using System;
using System.Net.Http;

namespace PlannR.App.Infrastructure
{
    public static class ClientInfrastructureServicesCollectionRegistration
    {
        public static IServiceCollection AddClientInfrastructureServices(this IServiceCollection services)
        {
            services.AddAuthorizationCore();

            services.AddScoped<AuthenticationStateProvider, PlannrAuthenticationStateProvider>();

            services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            });

            //services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:5001"));

            return services;
        }
    }
}
