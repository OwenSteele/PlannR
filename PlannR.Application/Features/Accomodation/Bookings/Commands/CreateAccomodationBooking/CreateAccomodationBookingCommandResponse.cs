using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.CreateAccomodationBooking
{
    public class CreateAccomodationBookingCommandResponse : BaseResponse
    {
        public CreateAccomodationBookingCommandResponse() : base()
        {

        }
        public Guid BookingId { get; set; }
    }
}
