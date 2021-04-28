using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class TripRepository : BaseRepository<Trip>, ITripRepository
    {
        public TripRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }

        public Task<ICollection<Trip>> GetTripsByName(string name)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Trip>> GetAllTripsWithoutChildren()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Trip>> GetAllTripsOnTheseDateTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Trip>> GetAllTripsOnThisDateTime(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
