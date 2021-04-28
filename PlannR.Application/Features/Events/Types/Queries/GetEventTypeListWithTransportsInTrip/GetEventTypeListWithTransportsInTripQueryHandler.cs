using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeListWithEventsInTrip
{
    public class GetEventTypeListWithEventsInTripQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventTypeRepository _eventTypeRepository;

        public GetEventTypeListWithEventsInTripQueryHandler(IMapper mapper,
            IEventTypeRepository eventTypeRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<ICollection<EventTypeListWithEventsInTripViewModel>> Handle(GetEventTypeListWithEventsInTripQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventTypeRepository.GetAllEntityTypesWithEntitiesFromTripById(request.TripId))
                .Where(x => x.Events != null && x.Events.Any())
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<EventTypeListWithEventsInTripViewModel>>(result);
        }
    }
}
