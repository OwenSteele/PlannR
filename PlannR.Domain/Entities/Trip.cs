using PlannR.Domain.Common;
using PlannR.Domain.Shared;
using System;
using System.Collections.Generic;

namespace PlannR.Domain.Entities
{
    public class Trip : AuditableEntity
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public ICollection<Transport> Transports { get; set; }
        public ICollection<Route> Routes { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Accomodation> Accomodations { get; set; }
    }
}
