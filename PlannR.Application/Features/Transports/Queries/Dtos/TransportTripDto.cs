using System;

namespace PlannR.Application.Features.Transports.Dtos.GetTransportsList
{
    public class TransportTripDto
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
    }
}