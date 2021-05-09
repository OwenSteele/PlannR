using PlannR.Application.Features.Transports.Dtos.GetTransportsList;
using System;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsList
{
    public class TransportListDataModel
    {
        public Guid TransportId { get; set; }
        public Guid TripId { get; set; }
        public TransportTripDto Trip { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
    }
}
