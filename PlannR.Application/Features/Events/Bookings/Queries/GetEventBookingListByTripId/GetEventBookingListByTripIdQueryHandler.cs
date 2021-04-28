using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId
{
    public class GetEventBookingListByTripIdQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventBookingRepository _eventBookingRepository;

        public GetEventBookingListByTripIdQueryHandler(IMapper mapper,
            IEventBookingRepository eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<ICollection<EventBookingListByTripIdViewModel>> Handle(
            EventBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository.GetAllBookingsOfTripById(request.TripId))
                .Where(x => x.Event.TripId == request.TripId)
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<EventBookingListByTripIdViewModel>>(result);
        }

    }
}
