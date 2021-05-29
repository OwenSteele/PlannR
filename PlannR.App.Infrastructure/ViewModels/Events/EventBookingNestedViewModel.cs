using PlannR.App.Infrastructure.ViewModels.Base;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Event
{
    public class EventBookingNestedViewModel : BookingNestedBaseViewModel
    {
        public Guid EventId { get; set; }
    }
}
