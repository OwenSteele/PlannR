using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Transports.Bookings.Commands.CreateTransportBooking
{
    public class CreateTransportBookingCommandResponse : BaseResponse
    {
        public CreateTransportBookingCommandResponse() : base()
        {

        }
        public Guid BookingId { get; set; }
    }
}
