using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface ITransportTypeRepository : IAsyncRepository<TransportType>, IEntityTypeRepository<TransportType>
    {
        Task<ICollection<TransportType>> GetAllPublicTransportTypes();
        Task<ICollection<TransportType>> GetAllNonPublicTransportTypes();
        Task<ICollection<TransportType>> GetAllTransportTypesWithFixedRoute();
        Task<ICollection<TransportType>> GetAllTransportTypesWithNonFixedRoute();
    }
}
