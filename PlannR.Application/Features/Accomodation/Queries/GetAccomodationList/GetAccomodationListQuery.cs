using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsList
{
    public class GetAccomodationListQuery : IRequest<ICollection<AccomodationListViewModel>>
    {
    }
}
