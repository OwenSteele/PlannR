using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingDetail
{
    public class GetTransportBookingDetailQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportBookingRepository _transportBookingRepository;

        public GetTransportBookingDetailQueryHandler(IMapper mapper,
            ITransportBookingRepository transportBookingRepository)
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
