using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripsList
{
    public class GetTripListQueryHandler : IRequestHandler<GetTripListQuery, ICollection<TripListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Trip> _authorisationService;
        private readonly ITripRepository _tripRepository;

        public GetTripListQueryHandler(IAuthorisationService<Trip> authorisationService, IMapper mapper,
            ITripRepository tripRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _tripRepository = tripRepository;
        }

        public async Task<ICollection<TripListDataModel>> Handle(GetTripListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _tripRepository.ListAllAsync()).OrderBy(x => x.StartDateTime).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<TripListDataModel>>(authorisedResult);
        }
    }
}
