using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingDetail
{
    public class GetEventBookingDetailQueryHandler : IRequestHandler<GetEventBookingDetailQuery, EventBookingDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<EventBooking> _authorisationService;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;

        public GetEventBookingDetailQueryHandler(IAuthorisationService<EventBooking> authorisationService, IMapper mapper,
            IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<EventBookingDetailViewModel> Handle(GetEventBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository.GetByIdAsync(request.Id));


            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<EventBookingDetailViewModel>(result);
        }
    }
}
