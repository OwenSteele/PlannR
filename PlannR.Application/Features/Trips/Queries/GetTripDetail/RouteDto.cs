using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class RouteDto
    {
        public Guid RouteId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}