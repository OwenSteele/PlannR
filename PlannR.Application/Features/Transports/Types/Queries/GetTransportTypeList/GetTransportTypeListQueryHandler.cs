using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeList
{
    public class GetTransportTypeListQueryHandler : IRequestHandler<GetTransportTypeListQuery, ICollection<TransportTypeListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<TransportType> _authorisationService;
        private readonly IAsyncRepository<TransportType> _transportTypeRepository;

        public GetTransportTypeListQueryHandler(IAuthorisationService<TransportType> authorisationService, IMapper mapper,
            IAsyncRepository<TransportType> transportTypeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportTypeRepository = transportTypeRepository;
        }

        public async Task<ICollection<TransportTypeListDataModel>> Handle(GetTransportTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportTypeRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result, true);

            return _mapper.Map<ICollection<TransportTypeListDataModel>>(authorisedResult);
        }

    }
}
