using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Queries.GetTripsList
{
    public class GetTripListQuery : IRequest<ICollection<TripListDataModel>>
    {
    }
}
