using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Queries.GetEventsDetail
{
    public class GetEventDetailQuery : IRequest<ICollection<EventDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
