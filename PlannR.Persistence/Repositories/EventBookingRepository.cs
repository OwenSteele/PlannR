using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;

namespace PlannR.Persistence.Repositories
{
    public class EventBookingRepository : BookingBaseRepository<EventBooking>, IEventBookingRepository
    {
        public EventBookingRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }
    }
}
