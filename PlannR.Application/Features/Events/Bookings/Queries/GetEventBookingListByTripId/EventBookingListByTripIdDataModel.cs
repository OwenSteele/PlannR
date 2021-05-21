using System;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId
{
    public class EventBookingListByTripIdDataModel
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
    }
}
