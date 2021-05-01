using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingListByTripId
{
    public class GetAccomodationBookingListByTripIdQueryHandler
     : IRequestHandler<GetAccomodationBookingListByTripIdQuery, ICollection<AccomodationBookingListByTripIdViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;

        public GetAccomodationBookingListByTripIdQueryHandler(IMapper mapper,
           IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<ICollection<AccomodationBookingListByTripIdViewModel>> Handle(
            GetAccomodationBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.ListAllAsync())
                .Where(x => x.Accomodation.TripId == request.TripId)
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<AccomodationBookingListByTripIdViewModel>>(result);
        }
    }
}
