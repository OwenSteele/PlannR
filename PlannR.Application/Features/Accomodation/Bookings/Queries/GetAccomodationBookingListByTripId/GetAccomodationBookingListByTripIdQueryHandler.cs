using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingListByTripId
{
    public class GetAccomodationBookingListByTripIdQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationBookingRepository _accomodationBookingRepository;

        public GetAccomodationBookingListByTripIdQueryHandler(IMapper mapper,
            IAccomodationBookingRepository accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<ICollection<AccomodationBookingListByTripIdViewModel>> Handle(
            AccomodationBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.GetAllBookingsOfTripById(request.TripId))
                .Where(x => x.Accomodation.TripId == request.TripId)
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<AccomodationBookingListByTripIdViewModel>>(result);
        }

    }
}
