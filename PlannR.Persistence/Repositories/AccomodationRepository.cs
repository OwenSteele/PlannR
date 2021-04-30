using Microsoft.EntityFrameworkCore;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class AccomodationRepository : BaseRepository<Accomodation>, IAccomodationRepository
    {
        public AccomodationRepository(PlannrDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Accomodation>> GetAllOfTripById(Guid tripId)
        {
            return await _dbContext.Accomodations
                .Where(x => x.TripId == tripId)
                .Include(x => x.AccomodationType)
                .Include(x => x.Location)
                .ToArrayAsync();
        }

        public async Task<ICollection<Accomodation>> GetAllOfTripByIdWithBookings(Guid tripId)
        {
            return await _dbContext.Accomodations
                .Where(x => x.TripId == tripId && x.Booking != null)
                .Include(x => x.AccomodationType)
                .Include(x => x.Location)
                .Include(x => x.Booking)
                .ToArrayAsync();
        }

        public async Task<ICollection<Accomodation>> GetAllOnDateOfTripById(Guid tripId, DateTime date)
        {
            return await _dbContext.Accomodations
                .Where(x => x.TripId == tripId &&
                x.StartDateTime <= date && x.EndDateTime >= date)
                .Include(x => x.AccomodationType)
                .Include(x => x.Location)
                .ToArrayAsync();
        }

        public async Task<bool> IsBookedOnTheseDateTimes(DateTime start, DateTime end)
        {
            return await _dbContext.Accomodations
                .Where(x => (x.EndDateTime <= start && x.StartDateTime >= end)).AnyAsync();
        }
    }
}
