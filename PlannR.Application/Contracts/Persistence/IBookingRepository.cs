using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IBookingRepository<T> where T : class
    {
        Task<bool> IsBookedOnTheseDateTimes(DateTime start, DateTime end);
        Task<ICollection<T>> GetAllBookingsOfTripById(Guid tripId);
    }
}
