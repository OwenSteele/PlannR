using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingDetail
{
    public class GetTransportBookingDetailQuery : IRequest<ICollection<TransportBookingDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
