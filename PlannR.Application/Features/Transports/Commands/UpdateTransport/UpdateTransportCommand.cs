using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Commands.UpdateTransport
{
    public class UpdateTransportCommand : IRequest
    {
        public Guid TransportId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public Guid TransportTypeId { get; set; }
        public Guid StartLocationId { get; set; }
        public Guid EndLocationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid TransportBookingId { get; set; }
        public string Description { get; set; }

    }
}
