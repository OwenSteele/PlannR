using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Routes.Queries.GetRouteListOnDate
{
    public class GetRouteListOnDateQuery : IRequest<ICollection<RouteListOnDateDataModel>>
    {
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
    }
}
