using AutoMapper;
using MediatR;
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

        public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<Unit> Handle(DeleteEventBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _eventBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Event), request.BookingId);
            }

            await _eventBookingRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
