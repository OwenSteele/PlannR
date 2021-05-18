using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using PlannR.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly ILocationRepository _LocationRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Location> _authorisationService;

        public DeleteLocationCommandHandler(IAuthorisationService<Location> authorisationService, IMapper mapper, ILocationRepository LocationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _LocationRepository = LocationRepository;
        }

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var result = await _LocationRepository.GetByIdAsync(request.LocationId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Location), request.LocationId);
            }

            await _LocationRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
