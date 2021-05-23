using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommand : IRequest<CreateRouteCommandResponse>
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ICollection<Guid> Points { get; set; }
    }
}
