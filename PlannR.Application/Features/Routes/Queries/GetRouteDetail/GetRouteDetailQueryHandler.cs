using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Queries.GetRouteDetail
{
    public class GetRouteDetailQueryHandler : IRequestHandler<GetRouteDetailQuery, RouteDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _repository;

        public GetRouteDetailQueryHandler(IMapper mapper, IRouteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<RouteDetailViewModel> Handle(GetRouteDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetWithRelated(request.RouteId));

            return _mapper.Map<RouteDetailViewModel>(result);
        }
    }
}
