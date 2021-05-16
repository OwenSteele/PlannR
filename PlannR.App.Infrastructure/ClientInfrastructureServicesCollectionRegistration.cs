using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using PlannR.App.Infrastructure.Authentication;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services;
using PlannR.App.Infrastructure.Services.Base;
using System;
using System.Net.Http;
using System.Reflection;

namespace PlannR.App.Infrastructure
{
    public static class ClientInfrastructureServicesCollectionRegistration
    {
        public static IServiceCollection AddClientInfrastructureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddBlazoredLocalStorage();

            services.AddAuthorizationCore();

            services.AddScoped<AuthenticationStateProvider, PlannrAuthenticationStateProvider>();

            services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44363")
            });

            services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:44363"));

            services.AddScoped<IAuthenticationDataService, AuthenticationDataService>();

            services.AddScoped<IAccomodationDataService, AccomodationDataService>();
            services.AddScoped<ITransportDataService, TransportDataService>();
            services.AddScoped<IEventDataService, EventDataService>();

            services.AddScoped<IAccomodationBookingDataService, AccomodationBookingDataService>();
            services.AddScoped<ITransportBookingDataService, TransportBookingDataService>();
            services.AddScoped<IEventBookingDataService, EventBookingDataService>();

            services.AddScoped<IAccomodationTypeDataService, AccomodationTypeDataService>();
            services.AddScoped<IEventTypeDataService, EventTypeDataService>();
            services.AddScoped<ITransportTypeDataService, TransportTypeDataService>();

            services.AddScoped<ITripDataService, TripDataService>();
            services.AddScoped<IRouteDataService, RouteDataService>();

            return services;
        }
    }
}
