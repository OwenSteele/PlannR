using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail
{
    public class GetAccomodationBookingDetailQueryHandler : IRequestHandler<GetAccomodationBookingDetailQuery, AccomodationBookingDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;
        private readonly ILoggedInService _loggedinService;

        public GetAccomodationBookingDetailQueryHandler(IMapper mapper,
           IAsyncRepository<AccomodationBooking> accomodationBookingRepository,
           ILoggedInService loggedinService)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
            _loggedinService = loggedinService;
        }

        public async Task<AccomodationBookingDetailViewModel> Handle(GetAccomodationBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.GetByIdAsync(request.Id));

            if (!string.IsNullOrWhiteSpace(result.CreatedBy) && result.CreatedBy != _loggedinService.UserId)
                throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<AccomodationBookingDetailViewModel>(result);
        }
    }
}
