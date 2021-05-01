using PlannR.Domain.Common;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PlannR.Domain.EntityTypes
{
    public class TransportType : AuditableEntity
    {
        public Guid TransportTypeId { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool HasFixedRoute { get; set; }
        public ICollection<Transport> Transports { get; set; }
    }
}
