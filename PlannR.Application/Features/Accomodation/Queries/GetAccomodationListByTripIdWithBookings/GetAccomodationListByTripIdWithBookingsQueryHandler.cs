using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings
{
    public class GetAccomodationListByTripIdWithBookingsQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListByTripIdWithBookingsQueryHandler(IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListByTripIdWithBookingsViewModel>> Handle(AccomodationListByTripIdWithBookingsViewModel request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllOfTripByIdWithBookings(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<AccomodationListByTripIdWithBookingsViewModel>>(result);
        }
    }
}
