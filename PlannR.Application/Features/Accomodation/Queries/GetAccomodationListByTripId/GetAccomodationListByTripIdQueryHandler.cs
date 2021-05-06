using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripId
{
    public class GetAccomodationListByTripIdQueryHandler : IRequestHandler<GetAccomodationListByTripIdQuery, ICollection<AccomodationListByTripIdViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Accomodation> _authorisationService;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListByTripIdQueryHandler(IAuthorisationService<Accomodation> authorisationService, IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListByTripIdViewModel>> Handle(GetAccomodationListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<AccomodationListByTripIdViewModel>>(authorisedResult);
        }

    }
}
