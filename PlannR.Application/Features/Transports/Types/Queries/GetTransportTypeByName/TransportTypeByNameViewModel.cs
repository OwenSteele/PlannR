using System;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeByName
{
    public class TransportTypeByNameViewModel
    {
        public Guid TransportTypeId { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool HasFixedRoute { get; set; }
    }
}
