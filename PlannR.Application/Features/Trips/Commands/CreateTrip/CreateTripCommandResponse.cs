using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Trips.Commands.CreateTrip
{
    public class CreateTripCommandResponse : BaseResponse
    {
        public CreateTripCommandResponse() : base()
        {

        }
        public Guid TripId { get; set; }
    }
}
