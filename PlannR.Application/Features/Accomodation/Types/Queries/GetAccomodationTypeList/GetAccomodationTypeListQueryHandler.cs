using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList
{
    public class GetAccomodationTypeListQueryHandler : IRequestHandler<GetAccomodationTypeListQuery, ICollection<AccomodationTypeListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<AccomodationType> _authorisationService;
        private readonly IAsyncRepository<AccomodationType> _accomodationTypeRepository;

        public GetAccomodationTypeListQueryHandler(IAuthorisationService<AccomodationType> authorisationService, IMapper mapper,
           IAsyncRepository<AccomodationType> accomodationTypeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationTypeRepository = accomodationTypeRepository;
        }

        public async Task<ICollection<AccomodationTypeListDataModel>> Handle(GetAccomodationTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationTypeRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<AccomodationTypeListDataModel>>(authorisedResult);
        }

    }
}
