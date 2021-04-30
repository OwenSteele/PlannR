using AutoMapper;
using MediatR;
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

        public GetAccomodationBookingDetailQueryHandler(IMapper mapper,
           IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
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
