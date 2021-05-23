using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.RoutePoints.Commands.CreateRoutePointRange
{
    public class CreateRoutePointRangeCommand : IRequest<CreateRoutePointRangeCommandResponse>
    {
        public ICollection<CreateRoutePointCommand> RoutePointDtos { get; set; }
    }
}
