using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeList
{
    public class GetEventTypeListQueryHandler : IRequestHandler<GetEventTypeListQuery, ICollection<EventTypeListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<EventType> _authorisationService;
        private readonly IAsyncRepository<EventType> _eventTypeRepository;

        public GetEventTypeListQueryHandler(IAuthorisationService<EventType> authorisationService, IMapper mapper,
           IAsyncRepository<EventType> eventTypeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<ICollection<EventTypeListDataModel>> Handle(GetEventTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventTypeRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result,true);

            return _mapper.Map<ICollection<EventTypeListDataModel>>(authorisedResult);
        }

    }
}
