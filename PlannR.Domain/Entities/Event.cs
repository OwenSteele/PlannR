using PlannR.Domain.Common;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;
using System;

namespace PlannR.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public Guid EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public bool EmailReminderEnabled { get; set; }
        public TimeSpan? EmailReminderTimer { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public EventBooking Booking { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}
