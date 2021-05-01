using Microsoft.EntityFrameworkCore;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class TransportRepository : BaseRepository<Transport>, ITransportRepository
    {
        public TransportRepository(PlannrDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Transport> GetWithRelated(Guid id)
        {
            return await _dbContext.Transports.Where(x => x.TransportId == id)
                .Include(x => x.Trip)
                .Include(x => x.TransportType)
                .Include(x => x.StartLocation)
                .Include(x => x.EndLocation)
                .FirstOrDefaultAsync();
        }
        public async Task<ICollection<Transport>> GetAllOfTripById(Guid tripId)
        {
            return await _dbContext.Transports
                .Where(x => x.TripId == tripId)
                .Include(x => x.StartLocation)
                .ToArrayAsync();
        }

        public async Task<ICollection<Transport>> GetAllOfTripByIdWithBookings(Guid tripId)
        {
            return await _dbContext.Transports
                .Where(x => x.TripId == tripId && x.Booking != null)
                .Include(x => x.StartLocation)
                .Include(x => x.Booking)
                .ToArrayAsync();
        }

        public async Task<ICollection<Transport>> GetAllOnDateOfTripById(Guid tripId, DateTime date)
        {
            return await _dbContext.Transports
                .Where(x => x.TripId == tripId &&
                x.StartDateTime <= date && x.EndDateTime >= date)
                .Include(x => x.StartLocation)
                .ToArrayAsync();
        }

        public async Task<bool> IsBookedOnTheseDateTimes(DateTime start, DateTime end)
        {
            return await _dbContext.Transports
                .Where(x => (x.EndDateTime <= start && x.StartDateTime >= end)).AnyAsync();
        }
    }
}
