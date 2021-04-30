using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingListByTripId
{
    public class GetTransportBookingListByTripIdQuery : IRequest<ICollection<TransportBookingListByTripIdViewModel>>
    {
        public Guid TripId { get; set; }
    }
}
