using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList
{
    public class GetEventBookingListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;

        public GetEventBookingListQueryHandler(IMapper mapper,
            IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<ICollection<EventBookingListViewModel>> Handle(GetEventBookingListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<ICollection<EventBookingListViewModel>>(result);
        }
    }
}
