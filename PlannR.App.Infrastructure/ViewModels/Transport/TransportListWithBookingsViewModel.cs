using PlannR.App.Infrastructure.ViewModels.Nested;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Transport
{
    public class TransportListWithBookingsViewModel
    {
        public Guid TransportId { get; set; }
        public TripNestedViewModel Trip { get; set; }
        public string Name { get; set; }
        public TransportTypeNestedViewModel TransportType { get; set; }
        public LocationNestedViewModel StartLocation { get; set; }
        public LocationNestedViewModel EndLocation { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TransportBookingNestedViewModel Booking { get; set; }
        public string Description { get; set; }
    }
}