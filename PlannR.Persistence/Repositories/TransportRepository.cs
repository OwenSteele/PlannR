using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class TransportRepository : BaseRepository<Transport>, ITransportRepository
    {
        public TransportRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Transport>> GetAllOfTripById(Guid tripId)
        {
            var trip = (await _dbContext.Trips.FindAsync(tripId));
            return trip.Transports;
        }
    }
}
