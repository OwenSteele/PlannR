using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Events.Types.Commands.CreateEventType
{
    public class CreateEventTypeCommandResponse : BaseResponse
    {
        public CreateEventTypeCommandResponse() : base()
        {

        }
        public Guid EventTypeId { get; set; }
    }
}
