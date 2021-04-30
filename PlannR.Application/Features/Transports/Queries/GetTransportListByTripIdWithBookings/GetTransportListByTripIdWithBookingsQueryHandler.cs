using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings
{
    public class GetTransportListByTripIdWithBookingsQueryHandler
     : IRequestHandler<GetTransportListByTripIdWithBookingsQuery,ICollection<TransportListByTripIdWithBookingsViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ITransportRepository _transportRepository;

        public GetTransportListByTripIdWithBookingsQueryHandler(IMapper mapper,
            ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _transportRepository = transportRepository;
        }

        public async Task<ICollection<TransportListByTripIdWithBookingsViewModel>> Handle(GetTransportListByTripIdWithBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportRepository.GetAllOfTripByIdWithBookings(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<TransportListByTripIdWithBookingsViewModel>>(result);
        }
    }
}
