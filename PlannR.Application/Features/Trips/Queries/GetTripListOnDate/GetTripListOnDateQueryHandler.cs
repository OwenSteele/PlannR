using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripListOnDate
{
    public class GetTripListOnDateQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;

        public GetTripListOnDateQueryHandler(IMapper mapper,
            ITripRepository tripRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        public async Task<ICollection<TripListOnDateViewModel>> Handle(GetTripListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _tripRepository.GetAllTripsOnTheseDateTimes(request.DateTime, request.DateTime))
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<TripListOnDateViewModel>>(result);
        }
    }
}
