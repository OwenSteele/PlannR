using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName
{
    public class GetEventTypeByNameQueryHandler : IRequestHandler<GetEventTypeByNameQuery, ICollection<EventTypeByNameViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventType> _eventTypeRepository;

        public GetEventTypeByNameQueryHandler(IMapper mapper,
           IAsyncRepository<EventType> eventTypeRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<ICollection<EventTypeByNameViewModel>> Handle(GetEventTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var result = (await _eventTypeRepository.ListAllAsync())
                .Where(x => x.Name == request.Name);

            return _mapper.Map<ICollection<EventTypeByNameViewModel>>(result);
        }
    }
}
