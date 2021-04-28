using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public interface ITransportTypeRepository : IAsyncRepository<TransportType>
    {
        Task<TransportType> GetTransportTypeByName(string name);
        Task<ICollection<TransportType>> GetAllPublicTransportTypes();
        Task<ICollection<TransportType>> GetAllNonPublicTransportTypes();
        Task<ICollection<TransportType>> GetAllTransportTypesWithFixedRoute();
        Task<ICollection<TransportType>> GetAllTransportTypesWithNonFixedRoute();
        Task<ICollection<TransportType>> GetAllTransportTypesWithEventsFromTripById(Guid tripId);
    }
}
