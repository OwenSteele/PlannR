using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail
{
    public class GetAccomodationBookingDetailQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationBookingRepository _accomodationBookingRepository;

        public GetAccomodationBookingDetailQueryHandler(IMapper mapper,
            IAccomodationBookingRepository accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<AccomodationBookingDetailViewModel> Handle(GetAccomodationBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.GetByIdAsync(request.Id));

            return _mapper.Map<AccomodationBookingDetailViewModel>(result);
        }
    }
}
