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
        public AccomodationRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Accomodation>> GetAllOfTripById(Guid tripId)
        {
            var trip = (await _dbContext.Trips.FindAsync(tripId));
            return trip.Accomodations;
        }
    }
}
