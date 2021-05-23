using PlannR.Application.Responses;
using System;

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
