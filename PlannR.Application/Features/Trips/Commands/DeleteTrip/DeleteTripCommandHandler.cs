using AutoMapper;
using MediatR;
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

        public DeleteTripCommandHandler(IMapper mapper, ITripRepository tripRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var result = await _tripRepository.GetByIdAsync(request.TripId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Trip), request.TripId);
            }

            await _tripRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
