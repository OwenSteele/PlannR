using PlannR.Application.Features.Events.Dtos.GetEventsList;
using System;

namespace PlannR.Application.Features.Events.Queries.GetEventListOnDate
{
    public class EventListOnDateViewModel
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public EventTripDto Trip { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public EventTypeDto EventType { get; set; }
        public EventLocationDto Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
    }
}
