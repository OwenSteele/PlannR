using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Commands.DeleteEventBooking
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventBookingCommand>
    {
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<EventBooking> _authorisationService;

        public DeleteEventCommandHandler(IAuthorisationService<EventBooking> authorisationService, IMapper mapper, IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<Unit> Handle(DeleteEventBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _eventBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Event), request.BookingId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            await _eventBookingRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
