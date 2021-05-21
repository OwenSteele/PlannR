using System;

namespace PlannR.Application.Features.Transports.Dtos.GetTransportsList
{
    public class TransportTypeDto
    {
        public Guid TransportTypeId { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool HasFixedRoute { get; set; }
    }
}