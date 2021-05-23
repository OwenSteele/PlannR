using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.RoutePoints.Commands.DeleteRoutePointRange
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRoutePointRangeCommand>
    {
        private readonly IRoutePointRepository _routePointRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Route> _authorisationService;

        public DeleteRouteCommandHandler(IAuthorisationService<Route> authorisationService, IMapper mapper, IRoutePointRepository routePointRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _routePointRepository = routePointRepository;
        }

        public async Task<Unit> Handle(DeleteRoutePointRangeCommand request, CancellationToken cancellationToken)
        {
            var routePoints = new List<RoutePoint>();

            foreach(var id in request.RoutePointIds)
            {
                var result = await _routePointRepository.GetByIdAsync(id);

                if (result == null)throw new NotFoundException(nameof(Route), id);

                routePoints.Add(result);
            }

            await _routePointRepository.DeleteRangeAsync(routePoints);

            return Unit.Value;
        }

    }
}
