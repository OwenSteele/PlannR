using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class GetTransportsDetailQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportRepository _repository;

        public GetTransportsDetailQueryHandler(IMapper mapper, ITransportRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TransportsDetailViewModel> Handle(GetGetTransportDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetByIdAsync(request.Id));

            return _mapper.Map<TransportsDetailViewModel>(result);
        }
    }
}
