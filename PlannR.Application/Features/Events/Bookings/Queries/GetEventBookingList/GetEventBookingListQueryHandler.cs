using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList
{
    public class GetEventBookingListQueryHandler : IRequestHandler<GetEventBookingListQuery, ICollection<EventBookingListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<EventBooking> _authorisationService;
        private readonly IAsyncRepository<EventBooking> _eventBookingRepository;

        public GetEventBookingListQueryHandler(IAuthorisationService<EventBooking> authorisationService, IMapper mapper,
            IAsyncRepository<EventBooking> eventBookingRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventBookingRepository = eventBookingRepository;
        }

        public async Task<ICollection<EventBookingListDataModel>> Handle(GetEventBookingListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventBookingRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<EventBookingListDataModel>>(authorisedResult);
        }
    }
}
