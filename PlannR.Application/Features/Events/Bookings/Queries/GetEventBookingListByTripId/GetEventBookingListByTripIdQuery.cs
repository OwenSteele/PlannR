using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId
{
    public class GetEventBookingListByTripIdQuery : IRequest<ICollection<EventBookingListByTripIdDataModel>>
    {
        public Guid TripId { get; set; }
    }
}
