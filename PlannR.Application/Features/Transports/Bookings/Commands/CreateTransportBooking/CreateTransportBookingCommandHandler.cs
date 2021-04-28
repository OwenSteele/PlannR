using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Commands.CreateTransportBooking
{
    public class CreateTransportBookingCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportBookingRepository _transportBookingRepository;


        public CreateTransportBookingCommandHandler(IMapper mapper, ITransportBookingRepository transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<Guid> Handle(CreateTransportBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTransportBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<TransportBooking>(request);

            entity = await _transportBookingRepository.AddAsync(entity);

            return entity.TransportId;
        }
    }
}
