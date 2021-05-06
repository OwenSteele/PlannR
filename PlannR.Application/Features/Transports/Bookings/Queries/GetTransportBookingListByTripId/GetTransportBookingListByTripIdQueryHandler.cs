using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingListByTripId
{
    public class GetTransportBookingListByTripIdQueryHandler
     : IRequestHandler<GetTransportBookingListByTripIdQuery, ICollection<TransportBookingListByTripIdViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<TransportBooking> _authorisationService;
        private readonly IAsyncRepository<TransportBooking> _transportBookingRepository;

        public GetTransportBookingListByTripIdQueryHandler(IAuthorisationService<TransportBooking> authorisationService, IMapper mapper,
            IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<ICollection<TransportBookingListByTripIdViewModel>> Handle(
            GetTransportBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportBookingRepository.ListAllAsync())
                .Where(x => x.Transport.TripId == request.TripId)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<TransportBookingListByTripIdViewModel>>(authorisedResult);
        }

    }
}
