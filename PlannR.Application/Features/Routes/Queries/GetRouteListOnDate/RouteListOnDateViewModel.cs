using System;

namespace PlannR.Application.Features.Routes.Queries.GetRouteListOnDate
{
    public class RouteListOnDateDataModel
    {
        public Guid RouteId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
