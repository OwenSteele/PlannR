using MediatR;
using System;

namespace PlannR.Application.Features.Routes.Queries.GetRouteDetail
{
    public class GetRouteDetailQuery : IRequest<RouteDetailDataModel>
    {
        public Guid RouteId { get; set; }
    }
}
