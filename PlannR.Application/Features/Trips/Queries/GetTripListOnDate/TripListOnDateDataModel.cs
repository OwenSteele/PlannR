﻿using PlannR.Application.Features.Trips.Queries.Dtos;
using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripListOnDate
{
    public class TripListOnDateDataModel
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LocationDto StartLocation { get; set; }
        public LocationDto EndLocation { get; set; }
    }
}