using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Routes.Commands.UpdateRoute
{
    public class UpdateRouteCommand : IRequest
    {
        public Guid RouteId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ICollection<Guid> Points { get; set; }
    }
}
