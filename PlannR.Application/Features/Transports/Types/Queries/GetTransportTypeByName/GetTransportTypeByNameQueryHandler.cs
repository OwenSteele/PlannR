using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeByName
{
    public class GetTransportTypeByNameQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly ITransportRepository _transportRepository;

        public GetTransportTypeByNameQueryHandler(IMapper mapper,
            ITransportTypeRepository transportTypeRepository,
            ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _transportTypeRepository = transportTypeRepository;
            _transportRepository = transportRepository;
        }

        public async Task<ICollection<TransportTypeByNameViewModel>> Handle(GetTransportTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _transportTypeRepository.GetEntityTypeByName(request.Name);

            return _mapper.Map<ICollection<TransportTypeByNameViewModel>>(result);
        }
    }
}
