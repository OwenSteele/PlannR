using PlannR.Application.Responses;
using System;

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
