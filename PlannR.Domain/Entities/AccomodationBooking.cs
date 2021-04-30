using PlannR.Domain.Shared;
using System;

namespace PlannR.Domain.Entities
{
    public class AccomodationBooking : Booking
    {
        public Guid AccomodationId { get; set; }
        public Accomodation Accomodation { get; set; }
    }
}