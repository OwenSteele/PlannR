using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface ITripRepository : IAsyncRepository<Trip>
    {
        public Task<ICollection<Trip>> GetTripsByName(string name);
        public Task<ICollection<Trip>> GetAllTripsOnTheseDateTimes(DateTime start, DateTime end);
    }
}
