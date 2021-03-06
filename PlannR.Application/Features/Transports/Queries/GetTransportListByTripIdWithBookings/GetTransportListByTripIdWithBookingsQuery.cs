using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings
{
    public class GetTransportListByTripIdWithBookingsQuery : IRequest<ICollection<TransportListByTripIdWithBookingsDataModel>>
    {
        public Guid TripId { get; set; }
    }
}
