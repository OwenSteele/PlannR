using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList
{
    public class GetAccomodationTypeListQuery : IRequest<ICollection<AccomodationTypeListViewModel>>
    {

    }
}
