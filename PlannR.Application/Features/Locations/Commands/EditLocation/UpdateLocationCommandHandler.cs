using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly ILocationRepository _LocationRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Location> _authorisationService;

        public UpdateLocationCommandHandler(IAuthorisationService<Location> authorisationService, IMapper mapper, ILocationRepository LocationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _LocationRepository = LocationRepository;
        }

        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {

            var result = await _LocationRepository.GetByIdAsync(request.LocationId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Location), request.LocationId);
            }

            if (!_authorisationService.CanAccessEntity(result)) throw new NotAuthorisedException();

            var validator = new UpdateLocationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateLocationCommand), typeof(Location));

            await _LocationRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
