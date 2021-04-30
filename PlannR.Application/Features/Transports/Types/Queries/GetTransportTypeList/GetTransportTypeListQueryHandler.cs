using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeList
{
    public class GetTransportTypeListQueryHandler : IRequestHandler<GetTransportTypeListQuery,ICollection<TransportTypeListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TransportType> _transportTypeRepository;

        public GetTransportTypeListQueryHandler(IMapper mapper,
            IAsyncRepository<TransportType> transportTypeRepository)
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
