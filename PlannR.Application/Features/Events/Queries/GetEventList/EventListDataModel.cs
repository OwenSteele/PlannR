using PlannR.Application.Features.Events.Dtos.GetEventsList;
using System;

namespace PlannR.Application.Features.Events.Queries.GetEventsList
{
    public class EventListDataModel
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public EventTripDto Trip { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
    }
}
