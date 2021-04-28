using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;

namespace PlannR.Persistence.Repositories
{
    public class TransportBookingRepository : BookingBaseRepository<TransportBooking>, ITransportBookingRepository
    {
        public TransportBookingRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }
    }
}
