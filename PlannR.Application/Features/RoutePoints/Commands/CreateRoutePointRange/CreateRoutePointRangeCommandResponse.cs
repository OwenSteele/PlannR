using PlannR.Application.Responses;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.RoutePoints.Commands.CreateRoutePointRange
{
    public class CreateRoutePointRangeCommandResponse : BaseResponse
    {
        public CreateRoutePointRangeCommandResponse() : base()
        {

        }
        public List<Guid> RoutePointIds { get; set; } = new();
    }
}
