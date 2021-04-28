using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeListWithTransportsInTrip
{
    public class GetTransportTypeListWithTransportsInTripQuery : IRequest<ICollection<TransportTypeListWithTransportsInTripViewModel>>
    {
        public Guid TripId { get; set; }
    }
}

