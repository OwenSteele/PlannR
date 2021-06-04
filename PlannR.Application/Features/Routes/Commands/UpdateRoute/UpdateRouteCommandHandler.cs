using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Commands.UpdateRoute
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Route> _authorisationService;

        public UpdateRouteCommandHandler(IAuthorisationService<Route> authorisationService, IMapper mapper, IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _routeRepository = routeRepository;
        }

        public async Task<Unit> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {

            var result = await _routeRepository.GetByIdAsync(request.RouteId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Route), request.RouteId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            var validator = new UpdateRouteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateRouteCommand), typeof(Route));

            await _routeRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
