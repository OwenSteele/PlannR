using System;

namespace PlannR.Application.Features.Events.Dtos.GetEventsList
{
    public class EventTypeDto
    {
        public Guid EventTypeId { get; set; }
        public string Name { get; set; }
    }
}