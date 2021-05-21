using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingListByTripId
{
    public class GetTransportBookingListByTripIdQuery : IRequest<ICollection<TransportBookingListByTripIdDataModel>>
    {
        public Guid TripId { get; set; }
    }
}
