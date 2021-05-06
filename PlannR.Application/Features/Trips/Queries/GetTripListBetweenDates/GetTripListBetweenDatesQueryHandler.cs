using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripListBetweenDates
{
    public class GetTripListBetweenDatesQueryHandler : IRequestHandler<GetTripListBetweenDatesQuery, ICollection<TripListBetweenDatesViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Trip> _authorisationService;
        private readonly ITripRepository _tripRepository;

        public GetTripListBetweenDatesQueryHandler(IAuthorisationService<Trip> authorisationService, IMapper mapper,
            ITripRepository tripRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _tripRepository = tripRepository;
        }

        public async Task<ICollection<TripListBetweenDatesViewModel>> Handle(GetTripListBetweenDatesQuery request, CancellationToken cancellationToken)
        {
            var result = (await _tripRepository.GetAllTripsOnTheseDateTimes(request.StartDateTime, request.EndDateTime))
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<TripListBetweenDatesViewModel>>(authorisedResult);
        }
    }
}
