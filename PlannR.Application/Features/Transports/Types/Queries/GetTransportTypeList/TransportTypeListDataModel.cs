using System;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeList
{
    public class TransportTypeListDataModel
    {
        public Guid TransportTypeId { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool HasFixedRoute { get; set; }
    }
}
