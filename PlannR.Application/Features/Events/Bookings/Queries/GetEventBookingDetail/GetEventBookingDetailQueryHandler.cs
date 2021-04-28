using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingDetail
{
    public class GetEventBookingDetailQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventBookingRepository _eventBookingRepository;

        public GetEventBookingDetailQueryHandler(IMapper mapper,
            IEventBookingRepository eventBookingRepository)
        {
            _mapper = mapper;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<EventBookingDetailViewModel> Handle(GetEventBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository.GetByIdAsync(request.Id));

            return _mapper.Map<EventBookingDetailViewModel>(result);
        }
    }
}
