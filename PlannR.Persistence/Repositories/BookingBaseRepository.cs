using PlannR.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class BookingBaseRepository<T> : BaseRepository<T>, IBookingRepository<T> where T : class
    {
        public BookingBaseRepository(PlannRDbContext dbContext) : base(dbContext) { }
        
        public Task<ICollection<T>> GetAllBookingsOfTripById(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsBookedOnTheseDateTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
