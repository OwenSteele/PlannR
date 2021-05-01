using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IRouteRepository : IAsyncRepository<Route>
    {
        Task<Route> GetWithRelated(Guid id);
        Task<bool> IsRouteReservedOnTheseDateTimes(DateTime start, DateTime end);
        Task<ICollection<Route>> GetAllRoutesOnDate(DateTime date);
        Task<ICollection<Route>> GetAllRoutesOfTripById(Guid tripId);
    }
}
