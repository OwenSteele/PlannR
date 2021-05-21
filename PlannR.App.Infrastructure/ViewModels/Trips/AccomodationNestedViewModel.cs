using System;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class AccomodationNestedViewModel
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public int Nights { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
}
