using System;

namespace PlannR.App.Infrastructure.ViewModels.Event
{
    public class EventBookingNestedViewModel
    {
        public Guid BookingId { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}
