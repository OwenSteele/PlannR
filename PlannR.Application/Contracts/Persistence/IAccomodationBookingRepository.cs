using PlannR.Domain.Entities;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IAccomodationBookingRepository : IAsyncRepository<AccomodationBooking>, IBookingRepository<AccomodationBooking>
    {
    }
}
