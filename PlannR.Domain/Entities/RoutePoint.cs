using PlannR.Domain.Common;
using PlannR.Domain.Shared;
using System;

namespace PlannR.Domain.Entities
{
    public class RoutePoint : AuditableEntity
    {
        public Guid Id { get; set; }
        public Location Location { get; set; }
        public Event AssociatedEvent { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
