using System;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings
{
    public class AccomodationBookingDto
    {
        public Guid BookingId { get; set; }
        public Guid AccomodationId { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}