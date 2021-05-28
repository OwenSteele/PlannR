using PlannR.Application.Features.Transports.Dtos.GetTransportsList;
using PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings;
using System;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class TransportDetailDataModel
    {
        public Guid TransportId { get; set; }
        public TransportTripDto Trip { get; set; }
        public string Name { get; set; }
        public TransportTypeDto TransportType { get; set; }
        public TransportLocationDto StartLocation { get; set; }
        public TransportLocationDto EndLocation { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public TransportBookingDto Booking { get; set; }
    }
}
