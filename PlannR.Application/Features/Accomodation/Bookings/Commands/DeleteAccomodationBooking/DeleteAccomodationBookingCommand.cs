using MediatR;
using System;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.DeleteAccomodationBooking
{
    public class DeleteAccomodationBookingCommand : IRequest
    {
        public Guid BookingId { get; set; }
    }
}
