using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Bookings.Commands.CreateTransportBooking
{
    public class CreateTransportBookingCommand : IRequest<CreateTransportBookingCommandResponse>
    {
        public Guid TransportId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public ICollection<byte[]> Reservations { get; set; }
        public decimal Cost { get; set; }
    }
}
