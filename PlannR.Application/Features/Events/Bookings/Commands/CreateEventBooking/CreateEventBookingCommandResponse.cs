using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Events.Bookings.Commands.CreateEventBooking
{
    public class CreateEventBookingCommandResponse : BaseResponse
    {
        public CreateEventBookingCommandResponse() : base()
        {

        }
        public Guid BookingId { get; set; }
    }
}
