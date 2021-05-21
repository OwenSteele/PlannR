using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Locations.Queries.GetLocationsList
{
    public class GetLocationListQuery : IRequest<ICollection<LocationListDataModel>>
    {
        public Guid LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AltitudeInMetres { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
