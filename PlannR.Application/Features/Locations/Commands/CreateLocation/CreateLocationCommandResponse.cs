using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandResponse : BaseResponse
    {
        public CreateLocationCommandResponse() : base()
        {

        }
        public Guid LocationId { get; set; }
    }
}
