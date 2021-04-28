using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface ITripRepository
    {
        public Task<ICollection<Trip>> GetTripsByName(string name);
        public Task<ICollection<Trip>> GetAllTripsWithoutChildren();
        public Task<ICollection<Trip>> GetAllTripsOnTheseDateTimes(DateTime start, DateTime end);
        public Task<ICollection<Trip>> GetAllTripsOnThisDateTime(DateTime start, DateTime end);
    }
}
