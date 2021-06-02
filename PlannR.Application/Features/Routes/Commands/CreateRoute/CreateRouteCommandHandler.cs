using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, CreateRouteCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _routeRepository;
        private readonly IAuthorisationService<Route> _authorisationService;


        public CreateRouteCommandHandler(IAuthorisationService<Route> authorisationService, IMapper mapper, IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
            _authorisationService = authorisationService;
        }

        public async Task<CreateRouteCommandResponse> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            if (!_authorisationService.CanCreateEntity()) throw new NotAuthorisedException();

            var validator = new CreateRouteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<Route>(request);

            entity = await _routeRepository.AddAsync(entity);

            var response = new CreateRouteCommandResponse
            {
                RouteId = entity.RouteId,
                Success = true
            };

            return response;
        }
    }
}
