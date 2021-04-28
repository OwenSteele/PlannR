using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeList
{
    public class GetTransportTypeListQuery : IRequest<ICollection<TransportTypeListViewModel>>
    {

    }
}
