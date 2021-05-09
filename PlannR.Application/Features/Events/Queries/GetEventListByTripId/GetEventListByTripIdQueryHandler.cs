using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Queries.GetEventListByTripId
{
    public class GetEventListByTripIdQueryHandler : IRequestHandler<GetEventListByTripIdQuery, ICollection<EventListByTripIdDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Event> _authorisationService;
        private readonly IEventRepository _eventRepository;

        public GetEventListByTripIdQueryHandler(IAuthorisationService<Event> authorisationService, IMapper mapper,
            IEventRepository eventRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventRepository = eventRepository;
        }

        public async Task<ICollection<EventListByTripIdDataModel>> Handle(GetEventListByTripIdQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.TripId == request.TripId)
                .OrderBy(x => x.StartDateTime).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<EventListByTripIdDataModel>>(authorisedResult);
        }

    }
}
