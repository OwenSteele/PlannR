using PlannR.Domain.EntityTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IEventTypeRepository : IAsyncRepository<EventType>
    {
        Task<EventType> GetEventTypeByName(string name);
        Task<ICollection<EventType>> GetAllEventTypesWithEventsFromTripById(Guid tripId);
    }
}
