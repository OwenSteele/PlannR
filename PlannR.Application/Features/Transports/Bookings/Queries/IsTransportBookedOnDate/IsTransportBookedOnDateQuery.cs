using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Bookings.Queries.IsTransportBookedOnDate
{
    public class IsTransportBookedOnDateQuery : IRequest<ICollection<TransportBookedOnDateViewModel>>
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
