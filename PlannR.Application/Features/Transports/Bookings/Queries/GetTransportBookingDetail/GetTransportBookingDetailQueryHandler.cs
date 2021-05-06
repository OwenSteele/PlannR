using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingDetail
{
    public class GetTransportBookingDetailQueryHandler : IRequestHandler<GetTransportBookingDetailQuery, TransportBookingDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<TransportBooking> _authorisationService;
        private readonly IAsyncRepository<TransportBooking> _transportBookingRepository;

        public GetTransportBookingDetailQueryHandler(IAuthorisationService<TransportBooking> authorisationService, IMapper mapper,
            IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<TransportBookingDetailViewModel> Handle(GetTransportBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportBookingRepository.GetByIdAsync(request.Id));


            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<TransportBookingDetailViewModel>(result);
        }
    }
}
