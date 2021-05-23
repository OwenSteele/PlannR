using PlannR.App.Infrastructure.ViewModels.Nested;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Event
{
    public class EventListOnDateViewModel
    {
        public Guid EventId { get; set; }
        public TripNestedViewModel Trip { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public EventTypeNestedViewModel EventType { get; set; }
        public LocationNestedViewModel Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
    }
}