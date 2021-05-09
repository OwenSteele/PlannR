using PlannR.Application.Features.Trips.Queries.Dtos;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class TripDetailDataModel
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LocationDto StartLocation { get; set; }
        public LocationDto EndLocation { get; set; }
        public ICollection<TransportDto> Transports { get; set; }
        public ICollection<RouteDto> Routes { get; set; }
        public ICollection<EventDto> Events { get; set; }
        public ICollection<AccomodationDto> Accomodations { get; set; }
    }
}
