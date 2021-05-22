using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
