using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using PlannR.App.Infrastructure.Authentication;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Contracts.View;
using PlannR.App.Infrastructure.Services;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Services;
using System;
using System.Net.Http;
using System.Reflection;

namespace PlannR.App
{
    public static class ClientAppServicesCollectionRegistration
    {
        public static IServiceCollection AddClientAppServices(this IServiceCollection services)
        {
            services.AddScoped<ITripOrderingService, TripOrderingService>();
            services.AddScoped<IMapService, MapService>();

            return services;
        }
    }
}
