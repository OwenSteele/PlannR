using MediatR;
using System;

namespace PlannR.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommand : IRequest
    {
        public Guid LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AltitudeInMetres { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
