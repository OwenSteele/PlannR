using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList
{
    public class GetAccomodationTypeListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationTypeRepository _accomodationTypeRepository;

        public GetAccomodationTypeListQueryHandler(IMapper mapper,
            IAccomodationTypeRepository accomodationTypeRepository)
        {
            _mapper = mapper;
            _accomodationTypeRepository = accomodationTypeRepository;
        }

        public async Task<ICollection<AccomodationTypeListViewModel>> Handle(GetAccomodationTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationTypeRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<ICollection<AccomodationTypeListViewModel>>(result);
        }

    }
}
