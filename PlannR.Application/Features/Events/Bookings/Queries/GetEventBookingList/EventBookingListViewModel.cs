using System;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList
{
    public class EventBookingListDataModel
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}
