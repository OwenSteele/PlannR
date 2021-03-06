using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;

namespace PlannR.App.Infrastructure.ViewModels.Routes
{
    public class RouteDetailViewModel
    {
        public Guid RouteId { get; set; }
        public TripNestedViewModel Trip { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ICollection<RoutePointNestedViewModel> Points { get; set; }
    }
}