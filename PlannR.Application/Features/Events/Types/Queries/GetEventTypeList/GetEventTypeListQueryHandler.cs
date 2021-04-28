using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeList
{
    public class GetEventTypeListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventTypeRepository _eventTypeRepository;

        public GetEventTypeListQueryHandler(IMapper mapper,
            IEventTypeRepository eventTypeRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<ICollection<EventTypeListViewModel>> Handle(GetEventTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventTypeRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<ICollection<EventTypeListViewModel>>(result);
        }

    }
}
