using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsList
{
    public class GetAccomodationListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListQueryHandler(IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListViewModel>> Handle(GetAccomodationListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.ListAllAsync()).OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<AccomodationListViewModel>>(result);
        }
    }
}
