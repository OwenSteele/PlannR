using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListOnDate
{
    public class GetTransportListOnDateQuery : IRequest<ICollection<TransportListOnDateViewModel>>
    {
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
    }
}
