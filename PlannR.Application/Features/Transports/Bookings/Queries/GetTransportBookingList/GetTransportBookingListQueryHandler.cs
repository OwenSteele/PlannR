using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingList
{
    public class GetTransportBookingListQueryHandler : IRequestHandler<GetTransportBookingListQuery, ICollection<TransportBookingListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<TransportBooking> _authorisationService;
        private readonly IAsyncRepository<TransportBooking> _transportBookingRepository;

        public GetTransportBookingListQueryHandler(IAuthorisationService<TransportBooking> authorisationService, IMapper mapper,
            IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<ICollection<TransportBookingListDataModel>> Handle(GetTransportBookingListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportBookingRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<TransportBookingListDataModel>>(authorisedResult);
        }
    }
}
