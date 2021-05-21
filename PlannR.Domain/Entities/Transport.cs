using PlannR.Domain.Common;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;
using System;

namespace PlannR.Domain.Entities
{
    public class Transport : AuditableEntity
    {
        public Guid TransportId { get; set; }
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        public string Name { get; set; }
        public Guid TransportTypeId { get; set; }
        public TransportType TransportType { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TransportBooking Booking { get; set; }
        public string Description { get; set; }
    }
}
