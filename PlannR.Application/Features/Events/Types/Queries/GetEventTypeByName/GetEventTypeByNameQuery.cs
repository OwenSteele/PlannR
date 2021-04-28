using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName
{
    public class GetEventTypeByNameQuery : IRequest<ICollection<EventTypeByNameViewModel>>
    {
        public string Name { get; set; }
    }
}
