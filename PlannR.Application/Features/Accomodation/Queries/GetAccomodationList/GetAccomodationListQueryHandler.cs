using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsList
{
    public class GetAccomodationListQueryHandler : IRequestHandler<GetAccomodationListQuery, ICollection<AccomodationListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Accomodation> _authorisationService;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListQueryHandler(IAuthorisationService<Accomodation> authorisationService, IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListViewModel>> Handle(GetAccomodationListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.ListAllAsync()).OrderBy(x => x.StartDateTime).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<AccomodationListViewModel>>(authorisedResult);
        }
    }
}
