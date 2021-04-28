﻿using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripsList
{
    public class TripListWithoutChildrenViewModel
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
