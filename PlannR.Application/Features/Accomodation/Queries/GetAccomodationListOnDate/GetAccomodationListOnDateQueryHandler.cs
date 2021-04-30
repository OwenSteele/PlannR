using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListOnDate
{
    public class GetAccomodationListOnDateQueryHandler : IRequestHandler<GetAccomodationListOnDateQuery, ICollection<AccomodationListOnDateViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationRepository _accomodationRepository;

        public GetAccomodationListOnDateQueryHandler(IMapper mapper,
            IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<ICollection<AccomodationListOnDateViewModel>> Handle(GetAccomodationListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _accomodationRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.StartDateTime <= request.Date && x.EndDateTime >= request.Date)
                .OrderBy(x => x.Name);

            return _mapper.Map<ICollection<AccomodationListOnDateViewModel>>(result);
        }
    }
}
