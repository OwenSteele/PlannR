using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Queries.GetEventListOnDate
{
    public class GetEventListOnDateQuery : IRequest<ICollection<EventListOnDateDataModel>>
    {
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
    }
}
