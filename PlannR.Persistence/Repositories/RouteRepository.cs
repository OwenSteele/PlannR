using Microsoft.EntityFrameworkCore;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(PlannrDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Route> GetWithRelated(Guid id)
        {
            return await _dbContext.Routes.Where(x => x.RouteId == id)
                .Include(x => x.Trip)
                .Include(x => x.Points)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> IsRouteReservedOnTheseDateTimes(DateTime start, DateTime end)
        {
            return await _dbContext.Routes
                .Where(x => (x.EndDateTime <= start && x.StartDateTime >= end)).AnyAsync();
        }
        public async Task<ICollection<Route>> GetAllRoutesOnDate(DateTime date)
        {
            return await _dbContext.Routes
                .Where(x => (x.StartDateTime <= date && x.EndDateTime >= date)).ToArrayAsync();
        }
        public Task<ICollection<Route>> GetAllRoutesOfTripById(Guid tripId)
        {
            throw new NotImplementedException();
        }
    }
}
