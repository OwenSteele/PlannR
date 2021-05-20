using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Queries.GetTripNameList
{
    public class GetTripNameListQuery : IRequest<ICollection<TripNameListDataModel>>
    {
    }
}
