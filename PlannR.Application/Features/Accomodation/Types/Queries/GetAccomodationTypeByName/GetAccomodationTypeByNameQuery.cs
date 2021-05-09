using MediatR;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName
{
    public class GetAccomodationTypeByNameQuery : IRequest<AccomodationTypeByNameDataModel>
    {
        public string Name { get; set; }
    }
}
