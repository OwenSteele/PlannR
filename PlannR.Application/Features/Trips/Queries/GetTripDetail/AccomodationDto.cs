using PlannR.Application.Features.Trips.Queries.Dtos;
using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class AccomodationDto
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public int Nights { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LocationDto Location { get; set; }
    }
}