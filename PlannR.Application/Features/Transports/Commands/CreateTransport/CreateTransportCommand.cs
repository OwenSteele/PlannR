using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Commands.CreateTransport
{
    public class CreateTransportCommand : IRequest<CreateTransportCommandResponse>
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public Guid TransportTypeId { get; set; }
        public Guid? StartLocationId { get; set; }
        public Guid? EndLocationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
    }
}
