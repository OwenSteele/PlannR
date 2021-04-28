using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeListWithTransportsInTrip
{
    public class TransportTypeListWithTransportsInTripViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool HasFixedRoute { get; set; }
        public ICollection<Guid> TransportIds { get; set; }

    }
}
