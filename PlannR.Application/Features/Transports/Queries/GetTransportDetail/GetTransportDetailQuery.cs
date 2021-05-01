using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class GetTransportDetailQuery : IRequest<TransportDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
