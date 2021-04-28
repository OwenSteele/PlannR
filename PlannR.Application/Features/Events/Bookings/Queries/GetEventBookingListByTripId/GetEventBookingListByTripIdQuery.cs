using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId
{
    public class EventBookingListByTripIdQuery : IRequest<ICollection<EventBookingListByTripIdViewModel>>
    {
        public Guid TripId { get; set; }
    }
}
