using PlannR.Application.Responses;
using System;

namespace PlannR.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommandResponse : BaseResponse
    {
        public CreateRouteCommandResponse() : base()
        {

        }
        public Guid RouteId { get; set; }
    }
}
