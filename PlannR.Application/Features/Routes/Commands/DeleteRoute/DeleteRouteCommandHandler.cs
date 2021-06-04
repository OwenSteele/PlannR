using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Commands.DeleteRoute
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Route> _authorisationService;

        public DeleteRouteCommandHandler(IAuthorisationService<Route> authorisationService, IMapper mapper, IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _routeRepository = routeRepository;
        }

        public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var result = await _routeRepository.GetByIdAsync(request.RouteId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Route), request.RouteId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            await _routeRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
