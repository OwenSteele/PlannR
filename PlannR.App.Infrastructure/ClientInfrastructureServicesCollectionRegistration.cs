using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services;
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

            services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:5001"));

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
