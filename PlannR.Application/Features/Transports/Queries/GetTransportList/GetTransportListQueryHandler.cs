﻿using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsList
{
    public class GetTransportListQueryHandler : IRequestHandler<GetTransportListQuery, ICollection<TransportListDataModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Transport> _authorisationService;
        private readonly ITransportRepository _transportRepository;

        public GetTransportListQueryHandler(IAuthorisationService<Transport> authorisationService, IMapper mapper,
            ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportRepository = transportRepository;
        }

        public async Task<ICollection<TransportListDataModel>> Handle(GetTransportListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportRepository.ListAllAsync()).OrderBy(x => x.StartDateTime).ToList();

            var authorisedResult = _authorisationService.RemoveInAccessibleEntities(result);

            return _mapper.Map<ICollection<TransportListDataModel>>(authorisedResult);
        }
    }
}
