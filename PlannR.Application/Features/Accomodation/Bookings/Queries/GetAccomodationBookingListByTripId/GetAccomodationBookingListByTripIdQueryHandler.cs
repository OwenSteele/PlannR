using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
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
        private readonly IAuthorisationService<AccomodationBooking> _authorisationService;
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;

        public GetAccomodationBookingListByTripIdQueryHandler(IAuthorisationService<AccomodationBooking> authorisationService, IMapper mapper,
           IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<ICollection<AccomodationBookingListByTripIdViewModel>> Handle(
            GetAccomodationBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.ListAllAsync())
                .Where(x => x.Accomodation.TripId == request.TripId)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<AccomodationBookingListByTripIdViewModel>>(authorisedResult);
        }
    }
}
