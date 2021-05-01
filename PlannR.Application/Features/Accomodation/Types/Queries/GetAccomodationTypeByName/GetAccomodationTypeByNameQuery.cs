using MediatR;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName
{
    public class GetAccomodationTypeByNameQuery : IRequest<AccomodationTypeByNameViewModel>
    {
        public string Name { get; set; }
    }
}
