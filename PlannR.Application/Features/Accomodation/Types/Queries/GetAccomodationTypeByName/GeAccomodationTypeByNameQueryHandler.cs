using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName
{
    public class GetAccomodationTypeByNameQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationTypeRepository _accomodationTypeRepository;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationTypeByNameQueryHandler(IMapper mapper,
            IAccomodationTypeRepository accomodationTypeRepository,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationTypeRepository = accomodationTypeRepository;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationTypeByNameViewModel>> Handle(GetAccomodationTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _accomodationTypeRepository.GetEntityTypeByName(request.Name);

            return _mapper.Map<ICollection<AccomodationTypeByNameViewModel>>(result);
        }
    }
}
