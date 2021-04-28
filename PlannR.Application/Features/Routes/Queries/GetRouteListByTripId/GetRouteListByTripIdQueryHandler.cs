using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Queries.GetRouteListByTripId
{
    public class GetRouteListByTripIdQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _accomodationRepository;

        public GetRouteListByTripIdQueryHandler(IMapper mapper,
            IRouteRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<RouteListByTripIdViewModel>> Handle(RouteListByTripIdViewModel request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllRoutesOfTripById(request.TripId))
                .OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<RouteListByTripIdViewModel>>(result);
        }

    }
}
