using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsList
{
    public class GetTransportListQuery : IRequest<ICollection<TransportListViewModel>>
    {
    }
}
