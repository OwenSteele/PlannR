using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Contracts.Persistence.Seed;
using PlannR.Persistence.Repositories;
using PlannR.Persistence.Services.IO;

namespace PlannR.Persistence
{
    public static class PersistenceServicesCollectionRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<PlannrDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PlannrConnectionString"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IFileReaderService, FileReaderService>();

            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAccomodationRepository, AccomodationRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();

            return services;
        }
    }
}
