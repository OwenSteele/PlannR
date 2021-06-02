using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _LocationRepository;
        private readonly IAuthorisationService<Location> _authorisationService;


        public CreateLocationCommandHandler(IAuthorisationService<Location> authorisationService, IMapper mapper, ILocationRepository LocationRepository)
        {
            _mapper = mapper;
            _LocationRepository = LocationRepository;
            _authorisationService = authorisationService;
        }

        public async Task<CreateLocationCommandResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            if (!_authorisationService.CanCreateEntity()) throw new NotAuthorisedException();

            var validator = new CreateLocationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<Location>(request);

            entity = await _LocationRepository.AddAsync(entity);

            var response = new CreateLocationCommandResponse
            {
                LocationId = entity.LocationId,
                Success = true
            };

            return response;
        }
    }
}
