using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Commands.DeleteTransportBooking
{
    public class DeleteTransportCommandHandler : IRequestHandler<DeleteTransportBookingCommand>
    {
        private readonly IAsyncRepository<TransportBooking> _transportBookingRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<TransportBooking> _authorisationService;

        public DeleteTransportCommandHandler(IAuthorisationService<TransportBooking> authorisationService, IMapper mapper, IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<Unit> Handle(DeleteTransportBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _transportBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Transport), request.BookingId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            await _transportBookingRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
