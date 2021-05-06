using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingList
{
    public class GetAccomodationBookingListQueryHandler : IRequestHandler<GetAccomodationBookingListQuery, ICollection<AccomodationBookingListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<AccomodationBooking> _authorisationService;
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;

        public GetAccomodationBookingListQueryHandler(IAuthorisationService<AccomodationBooking> authorisationService, IMapper mapper,
           IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<ICollection<AccomodationBookingListViewModel>> Handle(GetAccomodationBookingListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<AccomodationBookingListViewModel>>(authorisedResult);
        }
    }
}
