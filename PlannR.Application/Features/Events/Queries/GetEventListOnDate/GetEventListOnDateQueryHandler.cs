using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Queries.GetEventListOnDate
{
    public class GetEventListOnDateQueryHandler : IRequestHandler<GetEventListOnDateQuery, ICollection<EventListOnDateViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Event> _authorisationService;
        private readonly IEventRepository _eventRepository;

        public GetEventListOnDateQueryHandler(IAuthorisationService<Event> authorisationService, IMapper mapper,
            IEventRepository eventRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventRepository = eventRepository;
        }

        public async Task<ICollection<EventListOnDateViewModel>> Handle(GetEventListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.StartDateTime <= request.Date && x.EndDateTime >= request.Date)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<EventListOnDateViewModel>>(authorisedResult);
        }
    }
}
