using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingDetail
{
    public class GetTransportBookingDetailQuery : IRequest<TransportBookingDetailDataModel>
    {
        public Guid Id { get; set; }
    }
}
