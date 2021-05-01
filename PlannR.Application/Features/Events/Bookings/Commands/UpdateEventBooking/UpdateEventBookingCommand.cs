using MediatR;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannR.Application.Features.Events.Bookings.Commands.UpdateEventBooking
{
    public class UpdateEventBookingCommand : IRequest
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public ICollection<byte[]> Reservations { get; set; }
        public decimal Cost { get; set; }

    }
}
