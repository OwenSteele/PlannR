using System;

namespace PlannR.Application.Features.Events.Queries.GetEventListByTripIdWithBookings
{
    public class EventBookingDto
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}