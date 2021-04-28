﻿using PlannR.Application.Features.Accomodations.Dtos.GetAccomodationsList;
using System;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripId
{
    public class AccomodationListByTripIdViewModel
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public TripDto Trip { get; set; }
        public string Name { get; set; }
        public AccomodationTypeDto AccomodationType { get; set; }
        public int Nights { get; set; }
        public string Description { get; set; }
        public LocationDto Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
