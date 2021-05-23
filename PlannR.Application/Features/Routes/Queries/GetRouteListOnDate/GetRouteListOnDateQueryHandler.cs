using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Queries.GetRouteListOnDate
{
    public class GetRouteListOnDateQueryHandler : IRequestHandler<GetRouteListOnDateQuery, ICollection<RouteListOnDateDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Route> _authorisationService;
        private readonly IRouteRepository _routeRepository;

        public GetRouteListOnDateQueryHandler(IAuthorisationService<Route> authorisationService, IMapper mapper,
            IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _routeRepository = routeRepository;
        }

        public async Task<ICollection<RouteListOnDateDataModel>> Handle(GetRouteListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _routeRepository.GetAllRoutesOnDate(request.Date))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<RouteListOnDateDataModel>>(authorisedResult);
        }
    }
}
