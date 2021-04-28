using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class GetTransportDetailQuery : IRequest<ICollection<TransportsDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
