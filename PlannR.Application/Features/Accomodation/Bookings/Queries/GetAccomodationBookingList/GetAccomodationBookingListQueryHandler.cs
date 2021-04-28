using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingList
{
    public class GetAccomodationBookingListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationBookingRepository _accomodationBookingRepository;

        public GetAccomodationBookingListQueryHandler(IMapper mapper,
            IAccomodationBookingRepository accomodationBookingRepository)
        {
            _mapper = mapper;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<ICollection<AccomodationBookingListViewModel>> Handle(GetAccomodationBookingListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<ICollection<AccomodationBookingListViewModel>>(result);
        }
    }
}
