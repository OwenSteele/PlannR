using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListOnDate
{
    public class GetTransportListOnDateQueryHandler : IRequestHandler<GetTransportListOnDateQuery, ICollection<TransportListOnDateViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Transport> _authorisationService;
        private readonly ITransportRepository _transportRepository;

        public GetTransportListOnDateQueryHandler(IAuthorisationService<Transport> authorisationService, IMapper mapper,
            ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportRepository = transportRepository;
        }

        public async Task<ICollection<TransportListOnDateViewModel>> Handle(GetTransportListOnDateQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportRepository.GetAllOfTripById(request.TripId))
                .Where(x => x.StartDateTime <= request.Date && x.EndDateTime >= request.Date)
                .OrderBy(x => x.Name).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<TransportListOnDateViewModel>>(authorisedResult);
        }
    }
}
