using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
