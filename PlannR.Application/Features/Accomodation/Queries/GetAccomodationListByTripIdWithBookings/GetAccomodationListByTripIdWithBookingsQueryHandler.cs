using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings
{
    public class GetAccomodationListByTripIdWithBookingsQueryHandler
        : IRequestHandler<GetAccomodationListByTripIdWithBookingsQuery, ICollection<AccomodationListByTripIdWithBookingsViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Accomodation> _authorisationService;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListByTripIdWithBookingsQueryHandler(IAuthorisationService<Accomodation> authorisationService, IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListByTripIdWithBookingsViewModel>> Handle(GetAccomodationListByTripIdWithBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllOfTripByIdWithBookings(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<AccomodationListByTripIdWithBookingsViewModel>>(authorisedResult);
        }
    }
}
