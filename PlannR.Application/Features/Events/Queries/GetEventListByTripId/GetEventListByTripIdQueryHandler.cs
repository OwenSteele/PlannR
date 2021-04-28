using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Queries.GetEventListByTripId
{
    public class GetEventListByTripIdQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public GetEventListByTripIdQueryHandler(IMapper mapper,
            IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<ICollection<EventListByTripIdViewModel>> Handle(EventListByTripIdViewModel request, CancellationToken cancellationToken)
        {
            var result = (await _eventRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<EventListByTripIdViewModel>>(result);
        }

    }
}
