using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.CreateAccomodationBooking
{
    public class CreateAccomodationBookingCommandHandler : IRequestHandler<CreateAccomodationBookingCommand, CreateAccomodationBookingCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;
        private readonly IAuthorisationService<AccomodationBooking> _authorisationService;


        public CreateAccomodationBookingCommandHandler(IAuthorisationService<AccomodationBooking> authorisationService, IMapper mapper, IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
            _authorisationService = authorisationService;
        }

        public async Task<CreateAccomodationBookingCommandResponse> Handle(CreateAccomodationBookingCommand request, CancellationToken cancellationToken)
        {
            if (!_authorisationService.CanCreateEntity()) throw new NotAuthorisedException();

            var validator = new CreateAccomodationBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<AccomodationBooking>(request);

            entity = await _accomodationBookingRepository.AddAsync(entity);

            var response = new CreateAccomodationBookingCommandResponse
            {
                BookingId = entity.BookingId,
                Success = true
            };

            return response;
        }
    }
}
