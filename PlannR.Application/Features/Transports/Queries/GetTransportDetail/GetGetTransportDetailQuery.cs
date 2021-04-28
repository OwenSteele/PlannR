using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class GetGetTransportDetailQuery : IRequest<ICollection<TransportsDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
