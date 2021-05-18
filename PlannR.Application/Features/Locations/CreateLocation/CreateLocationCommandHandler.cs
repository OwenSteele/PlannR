using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using PlannR.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _LocationRepository;


        public CreateLocationCommandHandler(IMapper mapper, ILocationRepository LocationRepository)
        {
            _mapper = mapper;
            _LocationRepository = LocationRepository;
        }

        public async Task<Guid> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLocationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<Location>(request);

            entity = await _LocationRepository.AddAsync(entity);

            return entity.LocationId;
        }
    }
}
