using PlannR.Domain.Entities;

namespace PlannR.Application.Contracts.Persistence
{
    public interface ITransportBookingRepository : IAsyncRepository<TransportBooking>, IBookingRepository<TransportBooking>
    {
    }
}
