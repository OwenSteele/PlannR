using PlannR.Domain.Entities;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IEventBookingRepository : IAsyncRepository<EventBooking>, IBookingRepository<EventBooking>
    {
    }
}
