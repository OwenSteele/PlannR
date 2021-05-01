using System;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName
{
    public class EventTypeByNameViewModel
    {
        public Guid EventTypeId { get; set; }
        public string Name { get; set; }
    }
}
