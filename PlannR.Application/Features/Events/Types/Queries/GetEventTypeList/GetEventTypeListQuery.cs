using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeList
{
    public class GetEventTypeListQuery : IRequest<ICollection<EventTypeListDataModel>>
    {

    }
}
