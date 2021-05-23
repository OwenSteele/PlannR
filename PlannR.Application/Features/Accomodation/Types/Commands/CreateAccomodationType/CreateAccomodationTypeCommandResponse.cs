using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType
{
    public class CreateAccomodationTypeCommandResponse : BaseResponse
    {
        public CreateAccomodationTypeCommandResponse() : base()
        {

        }
        public Guid AccomodationTypeId { get; set; }
    }
}
