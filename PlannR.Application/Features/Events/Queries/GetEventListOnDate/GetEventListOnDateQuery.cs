using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Queries.GetEventListOnDate
{
    public class GetEventListOnDateQuery : IRequest<ICollection<EventListOnDateViewModel>>
    {
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
    }
}
