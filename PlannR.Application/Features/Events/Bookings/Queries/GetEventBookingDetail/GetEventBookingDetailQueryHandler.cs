using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingDetail
{
    public class GetEventBookingDetailQueryHandler : IRequestHandler<GetEventBookingDetailQuery, EventBookingDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;

        public GetEventBookingDetailQueryHandler(IMapper mapper,
            IAsyncRepository<EventBooking> eventBookingRepository)
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
