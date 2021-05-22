using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Types.Commands.CreateTransportType
{
    public class CreateTransportTypeCommand : IRequest<CreateTransportTypeCommandResponse>
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool HasFixedRoute { get; set; }
    }
}
