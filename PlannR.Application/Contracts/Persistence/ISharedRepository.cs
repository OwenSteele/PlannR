using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface ISharedRepository<T>
    {
        Task<ICollection<T>> GetAllOfTripById(Guid tripId);
        Task<ICollection<T>> GetAllOfTripByIdWithBookings(Guid tripId);
        Task<ICollection<T>> GetAllOnDateOfTripById(Guid tripId, DateTime date);
        Task<bool> IsBookedOnTheseDateTimes(DateTime start, DateTime end);
    }
}
