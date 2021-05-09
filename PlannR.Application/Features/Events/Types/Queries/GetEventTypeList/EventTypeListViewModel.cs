using System;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeList
{
    public class EventTypeListDataModel
    {
        public Guid EventTypeId { get; set; }
        public string Name { get; set; }
    }
}
