using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class TripDetailViewModel
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LocationNestedViewModel StartLocation { get; set; }
        public LocationNestedViewModel EndLocation { get; set; }
        public ICollection<TransportNestedViewModel> Transports { get; set; }
        public ICollection<RouteNestedViewModel> Routes { get; set; }
        public ICollection<EventNestedViewModel> Events { get; set; }
        public ICollection<AccomodationNestedViewModel> Accomodations { get; set; }
    }
}