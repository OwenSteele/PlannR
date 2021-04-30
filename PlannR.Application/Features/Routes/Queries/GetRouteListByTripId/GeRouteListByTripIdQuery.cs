using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Routes.Queries.GetRouteListByTripId
{
    public class GetRouteListByTripIdQuery : IRequest<ICollection<RouteListByTripIdViewModel>>
    {
        public Guid TripId { get; set; }
    }
}
