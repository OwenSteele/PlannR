using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.UpdateAccomodationBooking
{
    public class UpdateAccomodationBookingCommandHandler : IRequestHandler<UpdateAccomodationBookingCommand>
    {
        private readonly IAccomodationBookingRepository _accomodationBookingRepository;
        private readonly IMapper _mapper;

        public UpdateAccomodationBookingCommandHandler(IMapper mapper, IAccomodationBookingRepository accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<Unit> Handle(UpdateAccomodationBookingCommand request, CancellationToken cancellationToken)
        {

            var result = await _accomodationBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Accomodation), request.BookingId);
            }

            var validator = new UpdateAccomodationBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateAccomodationBookingCommand), typeof(Accomodation));

            await _accomodationBookingRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
