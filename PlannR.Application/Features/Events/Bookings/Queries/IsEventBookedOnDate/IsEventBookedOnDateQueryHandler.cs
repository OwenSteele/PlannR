using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.IsEventBookedOnDate
{
    public class IsEventBookedOnDateQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventBookingRepository _eventBookingRepository;

        public IsEventBookedOnDateQueryHandler(IMapper mapper,
            IEventBookingRepository eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<ICollection<EventBookedOnDateViewModel>> Handle(
            IsEventBookedOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository
            .IsBookedOnTheseDateTimes(request.StartDateTime, request.EndDateTime));

            return _mapper.Map<ICollection<EventBookedOnDateViewModel>>(result);
        }
    }
}
