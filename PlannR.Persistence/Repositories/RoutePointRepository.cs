using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class RoutePointRepository : BaseRepository<RoutePoint>, IRoutePointRepository
    {
        public RoutePointRepository(PlannrDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<RoutePoint>> AddRangeAsync(ICollection<RoutePoint> routePoints)
        {
            await _dbContext.RoutePoints.AddRangeAsync(routePoints);
            await _dbContext.SaveChangesAsync();

            return routePoints;
        }
        public async Task DeleteRangeAsync(ICollection<RoutePoint> routePoints)
        {
            _dbContext.RoutePoints.RemoveRange(routePoints);
            await _dbContext.SaveChangesAsync();
        }
    }
}
