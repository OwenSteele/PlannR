using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId
{
    public class GetEventBookingListByTripIdQueryHandler : IRequestHandler<GetEventBookingListByTripIdQuery, ICollection<EventBookingListByTripIdDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<EventBooking> _authorisationService;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;

        public GetEventBookingListByTripIdQueryHandler(IAuthorisationService<EventBooking> authorisationService, IMapper mapper,
            IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<ICollection<EventBookingListByTripIdDataModel>> Handle(
            GetEventBookingListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository.ListAllAsync())
                .Where(x => x.Event.TripId == request.TripId)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<EventBookingListByTripIdDataModel>>(authorisedResult);
        }

    }
}
