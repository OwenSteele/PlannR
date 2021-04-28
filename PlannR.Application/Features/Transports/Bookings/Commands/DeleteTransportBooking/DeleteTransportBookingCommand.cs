using MediatR;
using System;

namespace PlannR.Application.Features.Transports.Bookings.Commands.DeleteTransportBooking
{
    public class DeleteTransportBookingCommand : IRequest
    {
        public Guid BookingId { get; set; }
    }
}
