using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Commands.CreateTrip
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, CreateTripCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;

        public CreateTripCommandHandler(IMapper mapper, ITripRepository tripRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        public async Task<CreateTripCommandResponse> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTripCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<Trip>(request);

            entity = await _tripRepository.AddAsync(entity);

            var response = new CreateTripCommandResponse
            {
                TripId = entity.TripId,
                Success = true
            };

            return response;
        }
    }
}
