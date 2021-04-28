using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.CreateAccomodationBooking
{
    public class CreateAccomodationBookingCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationBookingRepository _accomodationBookingRepository;


        public CreateAccomodationBookingCommandHandler(IMapper mapper, IAccomodationBookingRepository accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<Guid> Handle(CreateAccomodationBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccomodationBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<AccomodationBooking>(request);

            entity = await _accomodationBookingRepository.AddAsync(entity);

            return entity.AccomodationId;
        }
    }
}
