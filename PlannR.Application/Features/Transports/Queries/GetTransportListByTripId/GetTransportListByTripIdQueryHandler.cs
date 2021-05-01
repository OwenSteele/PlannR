using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListByTripId
{
    public class GetTransportListByTripIdQueryHandler : IRequestHandler<GetTransportListByTripIdQuery, ICollection<TransportListByTripIdViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ITransportRepository _transportRepository;

        public GetTransportListByTripIdQueryHandler(IMapper mapper,
            ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _transportRepository = transportRepository;
        }

        public async Task<ICollection<TransportListByTripIdViewModel>> Handle(GetTransportListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<TransportListByTripIdViewModel>>(result);
        }

    }
}
