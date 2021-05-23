using PlannR.App.Infrastructure.ViewModels.Base;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class EventNestedViewModel : NestedViewModel
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public string CompanyName { get; set; }
    }
}
