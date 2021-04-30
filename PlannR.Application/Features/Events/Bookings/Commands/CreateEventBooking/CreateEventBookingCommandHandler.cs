using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Commands.CreateEventBooking
{
    public class CreateEventBookingCommandHandler : IRequestHandler<CreateEventBookingCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;


        public CreateEventBookingCommandHandler(IMapper mapper, IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<Guid> Handle(CreateEventBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<EventBooking>(request);

            entity = await _eventBookingRepository.AddAsync(entity);

            return entity.EventId;
        }
    }
}
