using AutoMapper;
using MediatR;
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

        public DeleteTransportCommandHandler(IMapper mapper, IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<Unit> Handle(DeleteTransportBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _transportBookingRepository.GetByIdAsync(request.BookingId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Transport), request.BookingId);
            }

            await _transportBookingRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
