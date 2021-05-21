using PlannR.Domain.Shared;
using System;

namespace PlannR.Domain.Entities
{
    public class TransportBooking : Booking
    {
        public Guid TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
