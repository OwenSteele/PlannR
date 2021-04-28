using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeListWithEventsInTrip
{
    public class GetEventTypeListWithEventsInTripQuery : IRequest<ICollection<EventTypeListWithEventsInTripViewModel>>
    {
        public Guid TripId { get; set; }
    }
}

