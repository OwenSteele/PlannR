using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName
{
    public class GetEventTypeByNameQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IEventRepository _eventRepository;

        public GetEventTypeByNameQueryHandler(IMapper mapper,
            IEventTypeRepository eventTypeRepository,
            IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
            _eventRepository = eventRepository;
        }

        public async Task<ICollection<EventTypeByNameViewModel>> Handle(GetEventTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _eventTypeRepository.GetEntityTypeByName(request.Name);

            return _mapper.Map<ICollection<EventTypeByNameViewModel>>(result);
        }
    }
}
