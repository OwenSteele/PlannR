using System;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class TransportNestedViewModel
    {
        public Guid TransportId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
