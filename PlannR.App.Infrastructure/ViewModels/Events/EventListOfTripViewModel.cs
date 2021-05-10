using PlannR.App.Infrastructure.ViewModels.Nested;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Event
{
    public class EventListOfTripViewModel
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public int Nights { get; set; }
        public string Description { get; set; }
        public LocationNestedViewModel Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}