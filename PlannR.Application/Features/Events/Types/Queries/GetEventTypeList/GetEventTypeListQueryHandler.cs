using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeList
{
    public class GetEventTypeListQueryHandler : IRequestHandler<GetEventTypeListQuery, ICollection<EventTypeListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventType> _eventTypeRepository;

        public GetEventTypeListQueryHandler(IMapper mapper,
           IAsyncRepository<EventType> eventTypeRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<ICollection<EventTypeListViewModel>> Handle(GetEventTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventTypeRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<ICollection<EventTypeListViewModel>>(result);
        }

    }
}
