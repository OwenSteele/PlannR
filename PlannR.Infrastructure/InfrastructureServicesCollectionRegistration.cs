using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Infrastructure
{
    public static class InfrastructureServicesCollectionRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
