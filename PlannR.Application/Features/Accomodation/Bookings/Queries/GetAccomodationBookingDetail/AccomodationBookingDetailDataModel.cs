using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail
{
    public class AccomodationBookingDetailDataModel
    {
        public Guid BookingId { get; set; }
        public Guid AccomodationId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
        public ICollection<byte[]> Reservations { get; set; }
    }
}
