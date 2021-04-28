using PlannR.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Domain.Entities
{
    public class AccomodationBooking: Booking
    {
        public Guid BookingId { get; set; }
        public Guid AccomodationId { get; set; }
        public Accomodation Accomodation { get; set; }
    }
}