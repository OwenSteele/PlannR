using PlannR.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Domain.Entities
{
    public class EventBooking : Booking
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public Event @Event { get; set; }
    }
}
