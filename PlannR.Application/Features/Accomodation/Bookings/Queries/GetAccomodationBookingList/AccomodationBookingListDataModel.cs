using System;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingList
{
    public class AccomodationBookingListDataModel
    {
        public Guid BookingId { get; set; }
        public Guid AccomodationId { get; set; }
        public string Name { get; set; }
    }
}
