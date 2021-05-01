using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class GetTripDetailQueryHandler : IRequestHandler<GetTripDetailQuery, TripDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _repository;

        public GetTripDetailQueryHandler(IMapper mapper, ITripRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TripDetailViewModel> Handle(GetTripDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetByIdAsync(request.Id));

            return _mapper.Map<TripDetailViewModel>(result);
        }
    }
}
