using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripsList
{
    public class GetTripListQueryHandler : IRequestHandler<GetTripListQuery, ICollection<TripListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;

        public GetTripListQueryHandler(IMapper mapper,
            ITripRepository tripRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        public async Task<ICollection<TripListViewModel>> Handle(GetTripListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _tripRepository.ListAllAsync()).OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<TripListViewModel>>(result);
        }
    }
}
