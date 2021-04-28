using PlannR.Application.Features.Transports.Dtos.GetTransportsList;
using System;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings
{
    public class TransportListByTripIdWithBookingsViewModel
    {
        public Guid TransportId { get; set; }
        public Guid TripId { get; set; }
        public TripDto Trip { get; set; }
        public string Name { get; set; }
        public TransportTypeDto TransportType { get; set; }
        public LocationDto StartLocation { get; set; }
        public LocationDto EndLocation { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public Guid BookingId { get; set; }
        public TransportBookingDto Booking { get; set; }

    }
}
