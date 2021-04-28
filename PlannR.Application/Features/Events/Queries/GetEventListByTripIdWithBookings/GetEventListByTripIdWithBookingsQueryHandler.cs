using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Queries.GetEventListByTripIdWithBookings
{
    public class GetEventListByTripIdWithBookingsQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public GetEventListByTripIdWithBookingsQueryHandler(IMapper mapper,
            IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<ICollection<EventListByTripIdWithBookingsViewModel>> Handle(EventListByTripIdWithBookingsViewModel request, CancellationToken cancellationToken)
        {
            var result = (await _eventRepository.GetAllOfTripByIdWithBookings(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<EventListByTripIdWithBookingsViewModel>>(result);
        }
    }
}
