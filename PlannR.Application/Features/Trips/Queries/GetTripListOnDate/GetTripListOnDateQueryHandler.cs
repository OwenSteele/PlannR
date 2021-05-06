using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripListOnDate
{
    public class GetTripListOnDateQueryHandler : IRequestHandler<GetTripListOnDateQuery, ICollection<TripListOnDateViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Trip> _authorisationService;
        private readonly ITripRepository _tripRepository;

        public GetTripListOnDateQueryHandler(IAuthorisationService<Trip> authorisationService, IMapper mapper,
            ITripRepository tripRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _tripRepository = tripRepository;
        }

        public async Task<ICollection<TripListOnDateViewModel>> Handle(GetTripListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _tripRepository.GetAllTripsOnTheseDateTimes(request.DateTime, request.DateTime))
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<TripListOnDateViewModel>>(authorisedResult);
        }
    }
}
