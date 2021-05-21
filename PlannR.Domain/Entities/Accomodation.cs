using PlannR.Domain.Common;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;
using System;

namespace PlannR.Domain.Entities
{
    public class Accomodation : AuditableEntity
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        public string Name { get; set; }
        public Guid AccomodationTypeId { get; set; }
        public AccomodationType AccomodationType { get; set; }
        public decimal? CostPerNight { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public AccomodationBooking Booking { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}
