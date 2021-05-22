using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Commands.CreateTransport
{
    public class CreateTransportCommandResponse : BaseResponse
    {
        public CreateTransportCommandResponse() : base()
        {

        }
        public Guid TransportId { get; set; }
    }
}
