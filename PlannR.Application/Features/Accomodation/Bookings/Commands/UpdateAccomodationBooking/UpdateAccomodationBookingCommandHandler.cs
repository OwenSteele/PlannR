using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.UpdateAccomodationBooking
{
    public class UpdateAccomodationBookingCommandHandler : IRequestHandler<UpdateAccomodationBookingCommand>
    {
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<AccomodationBooking> _authorisationService;

        public UpdateAccomodationBookingCommandHandler(IAuthorisationService<AccomodationBooking> authorisationService, IMapper mapper, IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<Unit> Handle(UpdateAccomodationBookingCommand request, CancellationToken cancellationToken)
        {

            var result = await _accomodationBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Accomodation), request.BookingId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

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
