using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Queries.GetTripsList
{
    public class GetTripListWithoutChildrenQuery : IRequest<ICollection<TripListWithoutChildrenViewModel>>
    {
    }
}
