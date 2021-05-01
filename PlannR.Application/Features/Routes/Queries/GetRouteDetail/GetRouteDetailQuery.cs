using MediatR;
using System;

namespace PlannR.Application.Features.Routes.Queries.GetRouteDetail
{
    public class GetRouteDetailQuery : IRequest<RouteDetailViewModel>
    {
        public Guid RouteId { get; set; }
    }
}
