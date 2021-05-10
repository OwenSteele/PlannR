using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class TripListViewModel
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LocationNestedViewModel StartLocation { get; set; }
        public LocationNestedViewModel EndLocation { get; set; }
    }
}