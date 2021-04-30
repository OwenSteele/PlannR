using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Queries.GetEventListByTripIdWithBookings
{
    public class GetEventListByTripIdWithBookingsQuery : IRequest<ICollection<EventListByTripIdWithBookingsViewModel>>
    {
        public Guid TripId { get; set; }
    }
}
