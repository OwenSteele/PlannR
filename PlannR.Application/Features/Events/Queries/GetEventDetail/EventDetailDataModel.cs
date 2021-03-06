using PlannR.Application.Features.Events.Dtos.GetEventsList;
using PlannR.Application.Features.Events.Queries.GetEventListByTripIdWithBookings;
using System;

namespace PlannR.Application.Features.Events.Queries.GetEventsDetail
{
    public class EventDetailDataModel
    {
        public Guid EventId { get; set; }
        public EventTripDto Trip { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public EventTypeDto EventType { get; set; }
        public bool EmailReminderEnabled { get; set; }
        public TimeSpan? EmailReminderTimer { get; set; }
        public EventLocationDto Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public EventBookingDto Booking { get; set; }
    }
}
