using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Commands.CreateTransportBooking
{
    public class CreateTransportBookingCommandHandler : IRequestHandler<CreateTransportBookingCommand, CreateTransportBookingCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TransportBooking> _transportBookingRepository;


        public CreateTransportBookingCommandHandler(IMapper mapper, IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<CreateTransportBookingCommandResponse> Handle(CreateTransportBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTransportBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<TransportBooking>(request);

            entity = await _transportBookingRepository.AddAsync(entity);

            var response = new CreateTransportBookingCommandResponse
            {
                BookingId = entity.BookingId,
                Success = true
            };

            return response;
        }
    }
}
