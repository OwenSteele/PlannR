using PlannR.App.Infrastructure.ViewModels.Base;
using PlannR.App.Infrastructure.ViewModels.Nested;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class AccomodationNestedViewModel : NestedViewModel
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public int Nights { get; set; }
        public LocationNestedViewModel Location { get; set; }
    }
}
