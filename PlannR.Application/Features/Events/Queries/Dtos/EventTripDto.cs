using System;

namespace PlannR.Application.Features.Events.Dtos.GetEventsList
{
    public class EventTripDto
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
    }
}