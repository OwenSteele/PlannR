using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
            using PlannR.Application.Contracts.Identity;
            using PlannR.Application.Exceptions;

namespace PlannR.Application.Features.RoutePoints.Commands.CreateRoutePointRange
{
    public class CreateRoutePointRangeCommandHandler : IRequestHandler<CreateRoutePointRangeCommand, CreateRoutePointRangeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRoutePointRepository _routePointRepository;
private readonly IAuthorisationService<RoutePoint> _authorisationService;


        public CreateRoutePointRangeCommandHandler(IAuthorisationService<RoutePoint> authorisationService, IMapper mapper,IRoutePointRepository routePointRepository)
        {
            _mapper = mapper;
            _routePointRepository = routePointRepository;
        _authorisationService = authorisationService;
        }

        public async Task<CreateRoutePointRangeCommandResponse> Handle(CreateRoutePointRangeCommand request, CancellationToken cancellationToken)
        {
            if (!_authorisationService.CanCreateEntity()) throw new NotAuthorisedException();

            var entities = _mapper.Map<ICollection<RoutePoint>>(request.RoutePointDtos);

            entities = await _routePointRepository.AddRangeAsync(entities);

            var response = new CreateRoutePointRangeCommandResponse();

            foreach(var point in entities)
            {
                response.RoutePointIds.Add(point.Id);
            }

            return response;
        }
    }
}
