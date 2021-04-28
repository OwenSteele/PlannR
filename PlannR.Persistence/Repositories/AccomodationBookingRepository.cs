using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class AccomodationBookingRepository : BookingBaseRepository<AccomodationBooking>, IAccomodationBookingRepository
    {
        public AccomodationBookingRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }
    }
}
