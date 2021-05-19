using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Locations.Queries.GetLocationsList
{
    public class GetLocationListQueryHandler : IRequestHandler<GetLocationListQuery, ICollection<LocationListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Location> _authorisationService;
        private readonly ILocationRepository _LocationRepository;

        public GetLocationListQueryHandler(IAuthorisationService<Location> authorisationService, IMapper mapper,
            ILocationRepository LocationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _LocationRepository = LocationRepository;
        }

        public async Task<ICollection<LocationListDataModel>> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _LocationRepository.ListAllAsync()).OrderBy(x => x.LastModifiedDate).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<LocationListDataModel>>(authorisedResult);
        }
    }
}
