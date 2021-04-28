using PlannR.Domain.Common;
using System;

namespace PlannR.Domain.Shared
{
    public class Location : AuditableEntity
    {
        public Guid LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AltitudeInMetres { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
