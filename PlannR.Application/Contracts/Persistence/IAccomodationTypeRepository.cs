using PlannR.Domain.EntityTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IAccomodationTypeRepository : IAsyncRepository<AccomodationType>
    {
        Task<AccomodationType> GetByName(string name);
        Task<ICollection<AccomodationType>> GetAllAccomodationTypesWithAccomodationsFromTripById(Guid tripId);
    }
}
