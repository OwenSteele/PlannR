using MediatR;
using System;

namespace PlannR.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public Guid EventTypeId { get; set; }
        public bool EmailReminderEnabled { get; set; }
        public TimeSpan? EmailReminderTimer { get; set; }
        public Guid LocationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid BookingId { get; set; }
        public string Description { get; set; }
    }
}
