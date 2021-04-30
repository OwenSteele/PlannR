using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId
{
    public class GetEventBookingListByTripIdQueryHandler : IRequestHandler<GetEventBookingListByTripIdQuery, ICollection<EventBookingListByTripIdViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;

        public GetEventBookingListByTripIdQueryHandler(IMapper mapper,
            IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<ICollection<EventBookingListByTripIdViewModel>> Handle(
            GetEventBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository.ListAllAsync())
                .Where(x => x.Event.TripId == request.TripId)
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<EventBookingListByTripIdViewModel>>(result);
        }

    }
}
