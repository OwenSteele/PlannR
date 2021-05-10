using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannR.App.Infrastructure.ViewModels.Event
{
    public class EventListWithBookingsViewModel
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public TripNestedViewModel Trip { get; set; }
        public string Name { get; set; }
        public decimal? CostPerNight { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public EventBookingNestedViewModel Booking { get; set; }
    }
}