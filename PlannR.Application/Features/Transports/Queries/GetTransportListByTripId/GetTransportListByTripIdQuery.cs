using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListByTripId
{
    public class GetTransportListByTripIdQuery : IRequest<ICollection<TransportListByTripIdDataModel>>
    {
        public Guid TripId { get; set; }
    }
}
