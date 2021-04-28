using System;

namespace PlannR.Application.Features.Routes.Queries.GetRouteDetail
{
    public class RoutePointDto
    {
        public Guid Id { get; set; }
        public LocationDto Location { get; set; }
        public Guid AssociatedEventId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
