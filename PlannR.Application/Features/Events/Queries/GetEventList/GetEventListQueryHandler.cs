using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, ICollection<EventListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public GetEventListQueryHandler(IMapper mapper,
            IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<ICollection<EventListViewModel>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventRepository.ListAllAsync()).OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<EventListViewModel>>(result);
        }
    }
}
