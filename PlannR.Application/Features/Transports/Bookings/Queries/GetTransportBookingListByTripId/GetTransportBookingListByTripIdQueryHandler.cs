using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingListByTripId
{
    public class GetTransportBookingListByTripIdQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportBookingRepository _transportBookingRepository;

        public GetTransportBookingListByTripIdQueryHandler(IMapper mapper,
            ITransportBookingRepository transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<ICollection<TransportBookingListByTripIdViewModel>> Handle(
            TransportBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportBookingRepository.GetAllBookingsOfTripById(request.TripId))
                .Where(x => x.Transport.TripId == request.TripId)
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<TransportBookingListByTripIdViewModel>>(result);
        }

    }
}
