using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Routes.Queries.GetRoutesList
{
    public class GetRouteListQuery : IRequest<ICollection<RouteListViewModel>>
    {
    }
}
