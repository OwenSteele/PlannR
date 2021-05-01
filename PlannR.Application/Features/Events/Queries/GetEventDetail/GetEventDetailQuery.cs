using MediatR;
using System;

namespace PlannR.Application.Features.Events.Queries.GetEventsDetail
{
    public class GetEventDetailQuery : IRequest<EventDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
