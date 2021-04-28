using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripListBetweenDates
{
    public class GetTripListBetweenDatesQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;

        public GetTripListBetweenDatesQueryHandler(IMapper mapper,
            ITripRepository tripRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        public async Task<ICollection<TripListBetweenDatesViewModel>> Handle(GetTripListBetweenDatesQuery request, CancellationToken cancellationToken)
        {
            var result = (await _tripRepository.GetAllTripsOnTheseDateTimes(request.StartDateTime, request.EndDateTime))
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<TripListBetweenDatesViewModel>>(result);
        }
    }
}
