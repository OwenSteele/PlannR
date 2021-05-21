using System;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList
{
    public class EventBookingListDataModel
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
    }
}
