using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsList
{
    public class GetGetTransportListQuery : IRequest<ICollection<TransportListViewModel>>
    {
    }
}
