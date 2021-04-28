using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeList
{
    public class GetTransportTypeListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportTypeRepository _transportTypeRepository;

        public GetTransportTypeListQueryHandler(IMapper mapper,
            ITransportTypeRepository transportTypeRepository)
        {
            _mapper = mapper;
            _transportTypeRepository = transportTypeRepository;
        }

        public async Task<ICollection<TransportTypeListViewModel>> Handle(GetTransportTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportTypeRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<ICollection<TransportTypeListViewModel>>(result);
        }

    }
}
