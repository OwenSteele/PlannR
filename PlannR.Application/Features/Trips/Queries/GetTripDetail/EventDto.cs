using PlannR.Application.Features.Trips.Queries.Dtos;
using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LocationDto Location { get; set; }
    }
}