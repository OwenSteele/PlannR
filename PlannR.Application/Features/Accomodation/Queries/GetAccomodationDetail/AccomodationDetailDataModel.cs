using PlannR.Application.Features.Accomodations.Dtos.GetAccomodationsList;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings;
using System;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail
{
    public class AccomodationDetailDataModel
    {
        public Guid AccomodationId { get; set; }
        public AccomodationTripDto Trip { get; set; }
        public string Name { get; set; }
        public AccomodationTypeDto AccomodationType { get; set; }
        public decimal? CostPerNight { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public AccomodationBookingDto Booking { get; set; }
        public string Description { get; set; }
        public AccomodationLocationDto Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
