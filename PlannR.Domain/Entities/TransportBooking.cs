using PlannR.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Domain.Entities
{
    public class TransportBooking : Booking
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
