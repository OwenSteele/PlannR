using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Queries.GetEventsDetail
{
    public class GetEventDetailQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _repository;

        public GetEventDetailQueryHandler(IMapper mapper, IEventRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<EventDetailViewModel> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetByIdAsync(request.Id));

            return _mapper.Map<EventDetailViewModel>(result);
        }
    }
}
