using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Routes.Queries.GetRouteDetail
{
    public class RouteDetailViewModel
    {
        public Guid RouteId { get; set; }
        public RouteTripDto Trip { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ICollection<RoutePointDto> Points { get; set; }
    }
}
