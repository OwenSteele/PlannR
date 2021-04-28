using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeListWithEventsInTrip
{
    public class EventTypeListWithEventsInTripViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guid> EventIds { get; set; }
    }
}
