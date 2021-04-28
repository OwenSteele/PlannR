using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList
{
    public class GetEventBookingListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventBookingRepository _eventBookingRepository;

        public GetEventBookingListQueryHandler(IMapper mapper,
            IEventBookingRepository eventBookingRepository)
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
