using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName
{
    public class GetAccomodationTypeByNameQueryHandler : IRequestHandler<GetAccomodationTypeByNameQuery, AccomodationTypeByNameViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AccomodationType> _accomodationTypeRepository;

        public GetAccomodationTypeByNameQueryHandler(IMapper mapper,
           IAsyncRepository<AccomodationType> accomodationTypeRepository)
        {
            _mapper = mapper;
            _accomodationTypeRepository = accomodationTypeRepository;
        }

        public async Task<AccomodationTypeByNameViewModel> Handle(GetAccomodationTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationTypeRepository.ListAllAsync())
                .Where(x => x.Name == request.Name).FirstOrDefault();

            return _mapper.Map<AccomodationTypeByNameViewModel>(result);
        }
    }
}
