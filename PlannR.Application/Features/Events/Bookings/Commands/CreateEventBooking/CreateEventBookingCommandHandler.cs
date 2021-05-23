using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Commands.CreateEventBooking
{
    public class CreateEventBookingCommandHandler : IRequestHandler<CreateEventBookingCommand, CreateEventBookingCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;


        public CreateEventBookingCommandHandler(IMapper mapper, IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<CreateEventBookingCommandResponse> Handle(CreateEventBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<EventBooking>(request);

            entity = await _eventBookingRepository.AddAsync(entity);

            var response = new CreateEventBookingCommandResponse
            {
                BookingId = entity.BookingId,
                Success = true
            };

            return response;
        }
    }
}
