using PlannR.Domain.Shared;
using System;

namespace PlannR.Domain.Entities
{
    public class EventBooking : Booking
    {
        public Guid EventId { get; set; }
        public Event @Event { get; set; }
    }
}
