using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannR.App.Infrastructure.ViewModels.Accomodation
{
    public class AccomodationListOnDateViewModel
    {
        public Guid AccomodationId { get; set; }
        public TripNestedViewModel Trip { get; set; }
        public string Name { get; set; }
        public int Nights { get; set; }
        public string Description { get; set; }
        public LocationNestedViewModel Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}