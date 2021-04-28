using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeListWithAccomodationsInTrip
{
    public class GetAccomodationTypeListWithAccomodationsInTripQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationTypeRepository _accomodationTypeRepository;

        public GetAccomodationTypeListWithAccomodationsInTripQueryHandler(IMapper mapper,
            IAccomodationTypeRepository accomodationTypeRepository)
        {
            _mapper = mapper;
            _accomodationTypeRepository = accomodationTypeRepository;
        }

        public async Task<ICollection<AccomodationTypeListWithAccomodationsInTripViewModel>> Handle(GetAccomodationTypeListWithAccomodationsInTripQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationTypeRepository.GetAllEntityTypesWithEntitiesFromTripById(request.TripId))
                .Where(x => x.Accomodations != null && x.Accomodations.Any())
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<AccomodationTypeListWithAccomodationsInTripViewModel>>(result);
        }
    }
}
