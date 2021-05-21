using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class GetTransportDetailQuery : IRequest<TransportDetailDataModel>
    {
        public Guid Id { get; set; }
    }
}
