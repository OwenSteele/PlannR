using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.DeleteAccomodationBooking
{
    public class DeleteAccomodationCommandHandler : IRequestHandler<DeleteAccomodationBookingCommand>
    {
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;
        private readonly IMapper _mapper;

        public DeleteAccomodationCommandHandler(IMapper mapper, IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<Unit> Handle(DeleteAccomodationBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _accomodationBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Accomodation), request.BookingId);
            }

            await _accomodationBookingRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
