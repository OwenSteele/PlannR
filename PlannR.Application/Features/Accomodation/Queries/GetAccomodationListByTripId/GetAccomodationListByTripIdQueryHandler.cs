using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripId
{
    public class GetAccomodationListByTripIdQueryHandler : IRequestHandler<GetAccomodationListByTripIdQuery, ICollection<AccomodationListByTripIdViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListByTripIdQueryHandler(IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListByTripIdViewModel>> Handle(GetAccomodationListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<AccomodationListByTripIdViewModel>>(result);
        }

    }
}
