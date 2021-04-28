using PlannR.Application.Features.Accomodations.Dtos.GetAccomodationsList;
using System;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings
{
    public class AccomodationListByTripIdWithBookingsViewModel
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public TripDto Trip { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public AccomodationTypeDto AccomodationType { get; set; }
        public LocationDto Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public AccomodationBookingDto Booking { get; set; }
    }
}
