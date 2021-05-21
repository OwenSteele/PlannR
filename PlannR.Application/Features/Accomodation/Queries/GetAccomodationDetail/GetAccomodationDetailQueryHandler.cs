using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail
{
    public class GetAccomodationDetailQueryHandler : IRequestHandler<GetAccomodationDetailQuery, AccomodationDetailDataModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Accomodation> _authorisationService;
        private readonly IAccomodationRepository _repository;

        public GetAccomodationDetailQueryHandler(IAuthorisationService<Accomodation> authorisationService, IMapper mapper,
            IAccomodationRepository repository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _repository = repository;
        }

        public async Task<AccomodationDetailDataModel> Handle(GetAccomodationDetailQuery request, CancellationToken cancellationToken)
        {
            var result = (await _repository.GetWithRelated(request.Id));


            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<AccomodationDetailDataModel>(result);
        }
    }
}
