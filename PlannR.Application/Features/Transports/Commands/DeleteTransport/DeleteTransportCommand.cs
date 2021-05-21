using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Commands.DeleteTransport
{
    public class DeleteTransportCommand : IRequest
    {
        public Guid TransportId { get; set; }
    }
}
