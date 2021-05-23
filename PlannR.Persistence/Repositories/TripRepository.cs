using Microsoft.EntityFrameworkCore;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class TripRepository : BaseRepository<Trip>, ITripRepository
    {
        public TripRepository(PlannrDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Trip>> GetTripsByName(string name)
        {
            return await _dbContext.Trips
                .Where(x => x.Name == name)
                .Include(x => x.Routes)
                .Include(x => x.Transports)
                .Include(x => x.Events)
                .Include(x => x.Accomodations)
                .ToArrayAsync();
        }
        public async Task<ICollection<Trip>> GetAllTripsOnTheseDateTimes(DateTime start, DateTime end)
        {
            return await _dbContext.Trips
                .Where(x => x.StartDateTime <= end && x.EndDateTime >= start)
                .Include(x => x.Routes)
                .Include(x => x.Transports)
                .Include(x => x.Events)
                .Include(x => x.Accomodations)
                .ToArrayAsync();
        }

        public async Task<Trip> GetByIdWithChildrenAsync(Guid tripId)
        {
            return await _dbContext.Trips
                .Where(x => x.TripId == tripId)
                .Include(x => x.Routes)
                .Include(x => x.Transports)
                .Include(x => x.Events)
                .Include(x => x.Accomodations)
                .FirstOrDefaultAsync();
        }
    }
}
