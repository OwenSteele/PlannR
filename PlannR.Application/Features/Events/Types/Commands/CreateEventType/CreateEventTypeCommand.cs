using MediatR;
using System;

namespace PlannR.Application.Features.Events.Types.Commands.CreateEventType
{
    public class CreateEventTypeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
