using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingDetail
{
    public class GetTransportBookingDetailQueryHandler : IRequestHandler<GetTransportBookingDetailQuery, TransportBookingDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TransportBooking> _transportBookingRepository;

        public GetTransportBookingDetailQueryHandler(IMapper mapper,
            IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<TransportBookingDetailViewModel> Handle(GetTransportBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportBookingRepository.GetByIdAsync(request.Id));

            return _mapper.Map<TransportBookingDetailViewModel>(result);
        }
    }
}
