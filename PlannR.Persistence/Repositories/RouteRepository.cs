using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }
        public Task<bool> IsRouteReservedOnTheseDateTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Route>> GetAllRoutesOnDate(DateTime date)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Route>> GetAllRoutesOfTripById(Guid tripId)
        {
            throw new NotImplementedException();
        }
    }
}
