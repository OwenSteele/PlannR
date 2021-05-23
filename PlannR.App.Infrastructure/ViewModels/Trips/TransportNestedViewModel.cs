using PlannR.App.Infrastructure.ViewModels.Base;
using PlannR.App.Infrastructure.ViewModels.Nested;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class TransportNestedViewModel : NestedViewModel
    {
        public Guid TransportId { get; set; }
        public Guid TripId { get; set; }
        public LocationNestedViewModel StartLocation { get; set; }
        public LocationNestedViewModel EndLocation { get; set; }
    }
}
