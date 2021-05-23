using PlannR.App.Infrastructure.ViewModels.Base;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class RouteNestedViewModel : NestedViewModel
    {
        public Guid RouteId { get; set; }
        public Guid TripId { get; set; }
    }
}
