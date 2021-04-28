using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Routes.Queries.GetRouteDetail
{
    public class GetRouteDetailQuery : IRequest<ICollection<RouteDetailViewModel>>
    {
        public Guid RouteId { get; set; }
    }
}
