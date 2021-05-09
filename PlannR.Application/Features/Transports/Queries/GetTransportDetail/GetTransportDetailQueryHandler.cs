using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsDetail
{
    public class GetTransportDetailQueryHandler : IRequestHandler<GetTransportDetailQuery, TransportDetailDataModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Transport> _authorisationService;
        private readonly ITransportRepository _repository;

        public GetTransportDetailQueryHandler(IAuthorisationService<Transport> authorisationService, IMapper mapper, ITransportRepository repository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _repository = repository;
        }

        public async Task<TransportDetailDataModel> Handle(GetTransportDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetWithRelated(request.Id));


            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<TransportDetailDataModel>(result);
        }
    }
}
