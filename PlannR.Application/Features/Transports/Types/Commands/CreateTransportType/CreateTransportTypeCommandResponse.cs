using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Commands.CreateTransportType
{
    public class CreateTransportTypeCommandResponse : BaseResponse
    {
        public CreateTransportTypeCommandResponse() : base()
        {

        }
        public Guid TransportTypeId { get; set; }        
    }
}
