using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Shared;

namespace PlannR.Persistence.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(PlannrDbContext dbContext) : base(dbContext)
        {
        }
    }
}
