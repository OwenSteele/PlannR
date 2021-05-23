using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IRoutePointRepository : IAsyncRepository<RoutePoint>
    {
        Task<ICollection<RoutePoint>> AddRangeAsync(ICollection<RoutePoint> routePoints);
        Task DeleteRangeAsync(ICollection<RoutePoint> routePoints);
    }
}
