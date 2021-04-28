using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.IsAccomodationBookedOnDate
{
    public class IsAccomodationBookedOnDateQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationBookingRepository _accomodationBookingRepository;

        public IsAccomodationBookedOnDateQueryHandler(IMapper mapper,
            IAccomodationBookingRepository accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<ICollection<AccomodationBookedOnDateViewModel>> Handle(
            IsAccomodationBookedOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository
            .IsBookedOnTheseDateTimes(request.StartDateTime, request.EndDateTime));

            return _mapper.Map<ICollection<AccomodationBookedOnDateViewModel>>(result);
        }
    }
}
