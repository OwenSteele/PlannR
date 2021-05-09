using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName
{
    public class GetAccomodationTypeByNameQueryHandler : IRequestHandler<GetAccomodationTypeByNameQuery, AccomodationTypeByNameDataModel>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<AccomodationType> _authorisationService;
        private readonly IAsyncRepository<AccomodationType> _accomodationTypeRepository;

        public GetAccomodationTypeByNameQueryHandler(IAuthorisationService<AccomodationType> authorisationService, IMapper mapper,
           IAsyncRepository<AccomodationType> accomodationTypeRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationTypeRepository = accomodationTypeRepository;
        }

        public async Task<AccomodationTypeByNameDataModel> Handle(GetAccomodationTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationTypeRepository.ListAllAsync())
                .Where(x => x.Name == request.Name).FirstOrDefault();


            if (!_authorisationService.CanAccessEntity(result)) throw new Exceptions.NotAuthorisedException();

            return _mapper.Map<AccomodationTypeByNameDataModel>(result);
        }
    }
}
