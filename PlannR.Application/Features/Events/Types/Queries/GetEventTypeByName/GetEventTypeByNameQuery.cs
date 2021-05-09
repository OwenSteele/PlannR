using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName
{
    public class GetEventTypeByNameQuery : IRequest<ICollection<EventTypeByNameDataModel>>
    {
        public string Name { get; set; }
    }
}
