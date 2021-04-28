using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripsList
{
    public class GetTripListWithoutChildrenQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;

        public GetTripListWithoutChildrenQueryHandler(IMapper mapper,
            ITripRepository tripRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        public async Task<ICollection<TripListWithoutChildrenViewModel>> Handle(GetTripListWithoutChildrenQuery request, CancellationToken cancellationToken)
        {
            var result = (await _tripRepository.GetAllTripsWithoutChildren()).OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<TripListWithoutChildrenViewModel>>(result);
        }
    }
}
