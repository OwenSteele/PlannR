using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Commands.UpdateEventBooking
{
    public class UpdateEventBookingCommandHandler : IRequestHandler<UpdateEventBookingCommand>
    {
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<EventBooking> _authorisationService;

        public UpdateEventBookingCommandHandler(IAuthorisationService<EventBooking> authorisationService, IMapper mapper, IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<Unit> Handle(UpdateEventBookingCommand request, CancellationToken cancellationToken)
        {

            var result = await _eventBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Event), request.BookingId);
            }

            var validator = new UpdateEventBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateEventBookingCommand), typeof(Event));

            await _eventBookingRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
