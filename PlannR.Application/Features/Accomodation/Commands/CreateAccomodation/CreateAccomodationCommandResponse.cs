using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Accomodations.Commands.CreateAccomodation
{
    public class CreateAccomodationCommandResponse : BaseResponse
    {
        public CreateAccomodationCommandResponse() : base()
        {

        }
        public Guid AccomodationId { get; set; }
    }
}
