using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList
{
    public class GetAccomodationTypeListQueryHandler : IRequestHandler<GetAccomodationTypeListQuery, ICollection<AccomodationTypeListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AccomodationType> _accomodationTypeRepository;

        public GetAccomodationTypeListQueryHandler(IMapper mapper,
           IAsyncRepository<AccomodationType> accomodationTypeRepository)
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
