using Plannr.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.IO;

namespace Plannr.App.Infrastructure.ViewModels.Accomodation
{
    public class AccomodationListWithBookingsViewModel
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public TripNestedViewModel Trip { get; set; }
        public string Name { get; set; }
        public decimal? CostPerNight { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public AccomodationBookingNestedViewModel Booking { get; set; }
    }
}