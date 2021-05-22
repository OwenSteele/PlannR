using PlannR.Application.Features.Trips.Queries.Dtos;
using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripsList
{
    public class TripListDataModel
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LocationDto StartLocation { get; set; }
        public LocationDto EndLocation { get; set; }
    }
}
