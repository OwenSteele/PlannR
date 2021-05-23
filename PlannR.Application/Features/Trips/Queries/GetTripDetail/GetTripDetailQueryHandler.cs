using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class GetTripDetailQueryHandler : IRequestHandler<GetTripDetailQuery, TripDetailDataModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Trip> _authorisationService;
        private readonly ITripRepository _repository;

        public GetTripDetailQueryHandler(IAuthorisationService<Trip> authorisationService, IMapper mapper
            , ITripRepository repository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _repository = repository;
        }

        public async Task<TripDetailDataModel> Handle(GetTripDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetByIdWithChildrenAsync(request.TripId));


            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<TripDetailDataModel>(result);
        }
    }
}
