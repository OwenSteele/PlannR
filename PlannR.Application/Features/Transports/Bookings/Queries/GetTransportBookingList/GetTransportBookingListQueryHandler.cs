using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingList
{
    public class GetTransportBookingListQueryHandler : IRequestHandler<GetTransportBookingListQuery, ICollection<TransportBookingListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TransportBooking> _transportBookingRepository;

        public GetTransportBookingListQueryHandler(IMapper mapper,
            IAsyncRepository<TransportBooking> transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<ICollection<TransportBookingListViewModel>> Handle(GetTransportBookingListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportBookingRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<ICollection<TransportBookingListViewModel>>(result);
        }
    }
}
