using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Locations.Queries.GetLocationsDetail
{
    public class GetLocationDetailQueryHandler : IRequestHandler<GetLocationDetailQuery, LocationDetailDataModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Location> _authorisationService;
        private readonly ILocationRepository _repository;

        public GetLocationDetailQueryHandler(IAuthorisationService<Location> authorisationService, IMapper mapper
            , ILocationRepository repository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _repository = repository;
        }

        public async Task<LocationDetailDataModel> Handle(GetLocationDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetByIdAsync(request.LocationId));

            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<LocationDetailDataModel>(result);
        }
    }
}
