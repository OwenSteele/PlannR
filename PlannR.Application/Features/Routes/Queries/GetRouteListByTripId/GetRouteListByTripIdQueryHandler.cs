using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Queries.GetRouteListByTripId
{
    public class GetRouteListByTripIdQueryHandler : IRequestHandler<GetRouteListByTripIdQuery, ICollection<RouteListByTripIdDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Route> _authorisationService;
        private readonly IRouteRepository _routeRepository;

        public GetRouteListByTripIdQueryHandler(IAuthorisationService<Route> authorisationService, IMapper mapper,
            IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _routeRepository = routeRepository;
        }

        public async Task<ICollection<RouteListByTripIdDataModel>> Handle(GetRouteListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _routeRepository.GetAllRoutesOfTripById(request.TripId))
                .OrderBy(x => x.StartDateTime).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<RouteListByTripIdDataModel>>(authorisedResult);
        }

    }
}
