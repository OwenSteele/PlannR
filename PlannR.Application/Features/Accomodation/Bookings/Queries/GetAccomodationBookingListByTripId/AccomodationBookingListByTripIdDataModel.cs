using System;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingListByTripId
{
    public class AccomodationBookingListByTripIdDataModel
    {
        public Guid BookingId { get; set; }
        public Guid AccomodationId { get; set; }
        public string Name { get; set; }
    }
}
