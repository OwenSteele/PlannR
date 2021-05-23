using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.RoutePoints.Commands.DeleteRoutePointRange
{
    public class DeleteRoutePointRangeCommand : IRequest
    {
        public ICollection<Guid> RoutePointIds { get; set; }
    }
}
