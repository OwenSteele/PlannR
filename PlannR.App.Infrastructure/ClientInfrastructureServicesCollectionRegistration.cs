using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using PlannR.App.Contracts.Guest;
using PlannR.App.Infrastructure.Authentication;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Contracts.Security;
using PlannR.App.Infrastructure.Services;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.Services.Guest;
using PlannR.App.Infrastructure.Services.Security;
using System;
using System.Net.Http;
using System.Reflection;

namespace PlannR.App.Infrastructure
{
    public static class ClientInfrastructureServicesCollectionRegistration
    {
        public static IServiceCollection AddClientInfrastructureServices(this IServiceCollection services,
            bool isDevelopment)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddBlazoredLocalStorage();

            services.AddAuthorizationCore();

            services.AddScoped<AuthenticationStateProvider, PlannrAuthenticationStateProvider>();

            var apiEndpoint = "https://plannr-api.azurewebsites.net/";

            if (isDevelopment) apiEndpoint = "https://localhost:44363";

            services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(apiEndpoint)
            });

            services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri(apiEndpoint));

            services.AddScoped<IClientInputService, ClientInputService>();

            services.AddScoped<IGuestService, GuestService>();
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
            services.AddScoped<IRoutePointDataService, RoutePointDataService>();
            services.AddScoped<ILocationDataService, LocationDataService>();

            return services;
        }
    }
}
