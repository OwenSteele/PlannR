using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeByName
{
    public class GetTransportTypeByNameQueryHandler : IRequestHandler<GetTransportTypeByNameQuery, ICollection<TransportTypeByNameDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<TransportType> _authorisationService;
        private readonly IAsyncRepository<TransportType> _transportTypeRepository;

        public GetTransportTypeByNameQueryHandler(IAuthorisationService<TransportType> authorisationService, IMapper mapper,
            IAsyncRepository<TransportType> transportTypeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportTypeRepository = transportTypeRepository;
        }

        public async Task<ICollection<TransportTypeByNameDataModel>> Handle(GetTransportTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportTypeRepository.ListAllAsync())
                .Where(x => x.Name == request.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result, true);

            return _mapper.Map<ICollection<TransportTypeByNameDataModel>>(authorisedResult);
        }
    }
}
