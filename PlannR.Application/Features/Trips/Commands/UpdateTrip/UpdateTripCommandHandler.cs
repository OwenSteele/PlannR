using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Trip> _authorisationService;

        public UpdateTripCommandHandler(IAuthorisationService<Trip> authorisationService, IMapper mapper, ITripRepository tripRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {

            var result = await _tripRepository.GetByIdAsync(request.TripId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Trip), request.TripId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            var validator = new UpdateTripCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateTripCommand), typeof(Trip));



            await _tripRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
