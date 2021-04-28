using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeByName
{
    public class GetTransportTypeByNameQuery : IRequest<ICollection<TransportTypeByNameViewModel>>
    {
        public string Name { get; set; }
    }
}
