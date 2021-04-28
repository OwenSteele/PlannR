using PlannR.Domain.Common;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PlannR.Domain.EntityTypes
{
    public class EventType : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
