using PlannR.Domain.Common;
using System;
using System.Collections.Generic;

namespace PlannR.Domain.Entities
{
    public class Route : AuditableEntity
    {
        public Guid RouteId { get; set; }
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        public string Name { get; set; }
        public ICollection<RoutePoint> Points { get; set; }
    }
}
