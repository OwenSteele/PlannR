using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventListQuery : IRequest<ICollection<EventListViewModel>>
    {
    }
}
