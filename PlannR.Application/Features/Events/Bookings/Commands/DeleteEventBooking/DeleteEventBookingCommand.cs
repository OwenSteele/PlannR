using MediatR;
using System;

namespace PlannR.Application.Features.Events.Bookings.Commands.DeleteEventBooking
{
    public class DeleteEventBookingCommand : IRequest
    {
        public Guid BookingId { get; set; }
    }
}
