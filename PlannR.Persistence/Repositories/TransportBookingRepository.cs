using PlannR.Domain.Entities;

namespace PlannR.Persistence.Repositories
{
    public interface ITransportBookingRepository : IAsyncRepository<TransportBooking>, IBookingRepository<TransportBooking>
    {
    }
}
