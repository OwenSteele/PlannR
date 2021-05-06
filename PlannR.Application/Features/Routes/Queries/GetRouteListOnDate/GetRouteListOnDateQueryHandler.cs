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
    public class GetRouteListOnDateQueryHandler : IRequestHandler<GetRouteListOnDateQuery, ICollection<RouteListOnDateViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Route> _authorisationService;
        private readonly IRouteRepository _accomodationRepository;

        public GetRouteListOnDateQueryHandler(IAuthorisationService<Route> authorisationService, IMapper mapper,
            IRouteRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<RouteListOnDateViewModel>> Handle(GetRouteListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllRoutesOnDate(request.Date))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<RouteListOnDateViewModel>>(authorisedResult);
        }
    }
}
