using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandResponse : BaseResponse
    {
        public CreateEventCommandResponse() : base()
        {

        }
        public Guid EventId { get; set; }
    }
}
