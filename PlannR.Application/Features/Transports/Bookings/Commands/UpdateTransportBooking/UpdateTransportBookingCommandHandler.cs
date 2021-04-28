using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Commands.UpdateTransportBooking
{
    public class UpdateTransportBookingCommandHandler : IRequestHandler<UpdateTransportBookingCommand>
    {
        private readonly ITransportBookingRepository _transportBookingRepository;
        private readonly IMapper _mapper;

        public UpdateTransportBookingCommandHandler(IMapper mapper, ITransportBookingRepository transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<Unit> Handle(UpdateTransportBookingCommand request, CancellationToken cancellationToken)
        {

            var result = await _transportBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Event), request.BookingId);
            }

            var validator = new UpdateTransportBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateTransportBookingCommand), typeof(Transport));

            await _transportBookingRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
