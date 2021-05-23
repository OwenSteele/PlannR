using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.RoutePoints.Commands.CreateRoutePointRange
{
    public class CreateRoutePointRangeCommandHandler : IRequestHandler<CreateRoutePointRangeCommand, CreateRoutePointRangeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRoutePointRepository _routePointRepository;


        public CreateRoutePointRangeCommandHandler(IMapper mapper, IRoutePointRepository routePointRepository)
        {
            _mapper = mapper;
            _routePointRepository = routePointRepository;
        }

        public async Task<CreateRoutePointRangeCommandResponse> Handle(CreateRoutePointRangeCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateRoutePointRangeCommandValidator();
            //var validationResult = await validator.ValidateAsync(request.);

            //if (validationResult.Errors.Count > 0)
            //    throw new Exceptions.ValidationException(validationResult);

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
