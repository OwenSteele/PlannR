using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeListWithTransportsInTrip
{
    public class GetTransportTypeListWithTransportsInTripQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportTypeRepository _transportTypeRepository;

        public GetTransportTypeListWithTransportsInTripQueryHandler(IMapper mapper,
            ITransportTypeRepository transportTypeRepository)
        {
            _mapper = mapper;
            _transportTypeRepository = transportTypeRepository;
        }

        public async Task<ICollection<TransportTypeListWithTransportsInTripViewModel>> Handle(GetTransportTypeListWithTransportsInTripQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportTypeRepository.GetAllEntityTypesWithEntitiesFromTripById(request.TripId))
                .Where(x => x.Transports != null && x.Transports.Any())
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<TransportTypeListWithTransportsInTripViewModel>>(result);
        }
    }
}
