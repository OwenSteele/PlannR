using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail
{
    public class GetAccomodationDetailQueryHandler : IRequestHandler<GetAccomodationDetailQuery, AccomodationDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationRepository _repository;

        public GetAccomodationDetailQueryHandler(IMapper mapper,
            IAccomodationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<AccomodationDetailViewModel> Handle(GetAccomodationDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetWithRelated(request.Id));

            return _mapper.Map<AccomodationDetailViewModel>(result);
        }
    }
}
