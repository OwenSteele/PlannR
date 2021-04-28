using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Bookings.Queries.IsTransportBookedOnDate
{
    public class IsTransportBookedOnDateQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportBookingRepository _transportBookingRepository;

        public IsTransportBookedOnDateQueryHandler(IMapper mapper,
            ITransportBookingRepository transportBookingRepository)
        {
            _mapper = mapper;
            _transportBookingRepository = transportBookingRepository;
        }

        public async Task<ICollection<TransportBookedOnDateViewModel>> Handle(
            IsTransportBookedOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportBookingRepository
            .IsBookedOnTheseDateTimes(request.StartDateTime, request.EndDateTime));

            return _mapper.Map<ICollection<TransportBookedOnDateViewModel>>(result);
        }
    }
}
