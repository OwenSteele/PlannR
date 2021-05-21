using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListOnDate
{
    public class GetAccomodationListOnDateQueryHandler : IRequestHandler<GetAccomodationListOnDateQuery, ICollection<AccomodationListOnDateDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Accomodation> _authorisationService;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListOnDateQueryHandler(IAuthorisationService<Accomodation> authorisationService, IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListOnDateDataModel>> Handle(GetAccomodationListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.StartDateTime <= request.Date && x.EndDateTime >= request.Date)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<AccomodationListOnDateDataModel>>(authorisedResult);
        }
    }
}
