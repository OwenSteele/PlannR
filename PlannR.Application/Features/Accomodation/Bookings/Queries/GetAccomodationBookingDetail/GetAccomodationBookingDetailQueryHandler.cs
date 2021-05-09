using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail
{
    public class GetAccomodationBookingDetailQueryHandler : IRequestHandler<GetAccomodationBookingDetailQuery, AccomodationBookingDetailDataModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<AccomodationBooking> _authorisationService;
        private readonly IAsyncRepository<AccomodationBooking> _accomodationBookingRepository;

        public GetAccomodationBookingDetailQueryHandler(IAuthorisationService<AccomodationBooking> authorisationService, IMapper mapper,
           IAsyncRepository<AccomodationBooking> accomodationBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationBookingRepository = accomodationBookingRepository;
        }

        public async Task<AccomodationBookingDetailDataModel> Handle(GetAccomodationBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationBookingRepository.GetByIdAsync(request.Id));

            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<AccomodationBookingDetailDataModel>(result);
        }
    }
}
