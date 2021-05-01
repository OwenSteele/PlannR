using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class GetTransportDetailQueryHandler : IRequestHandler<GetTransportDetailQuery, TransportDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ITransportRepository _repository;

        public GetTransportDetailQueryHandler(IMapper mapper, ITransportRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TransportDetailViewModel> Handle(GetTransportDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetWithRelated(request.Id));

            return _mapper.Map<TransportDetailViewModel>(result);
        }
    }
}
