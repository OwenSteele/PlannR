using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Trip> _authorisationService;

        public DeleteTripCommandHandler(IAuthorisationService<Trip> authorisationService, IMapper mapper, ITripRepository tripRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var result = await _tripRepository.GetByIdAsync(request.TripId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Trip), request.TripId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            await _tripRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
