using PlannR.Domain.Common;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PlannR.Domain.EntityTypes
{
    public class AccomodationType : AuditableEntity
    {
        public Guid AccomodationTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Accomodation> Accomodations { get; set; }
    }
}
