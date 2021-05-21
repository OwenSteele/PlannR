using MediatR;
using System;

namespace PlannR.Application.Features.Routes.Commands.DeleteRoute
{
    public class DeleteRouteCommand : IRequest
    {
        public Guid RouteId { get; set; }
    }
}
