using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PlannR.Application
{
    public static class ApplicationServicesCollectionRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
