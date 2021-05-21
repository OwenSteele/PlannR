using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommand : IRequest
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid StartLocationId { get; set; }
        public Guid EndLocationId { get; set; }
        public ICollection<Guid> TransportIds { get; set; }
        public ICollection<Guid> RouteIds { get; set; }
        public ICollection<Guid> EventIds { get; set; }
        public ICollection<Guid> AccomodationIds { get; set; }
    }
}
