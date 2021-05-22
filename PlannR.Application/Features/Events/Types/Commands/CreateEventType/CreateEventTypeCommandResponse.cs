using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
