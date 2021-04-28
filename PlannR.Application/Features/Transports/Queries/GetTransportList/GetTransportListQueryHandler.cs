﻿using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Queries.GetTransportsList
{
    public class GetTransportListQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITransportRepository _transportRepository;

        public GetTransportListQueryHandler(IMapper mapper,
            ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _transportRepository = transportRepository;
        }

        public async Task<ICollection<TransportListViewModel>> Handle(GetGetTransportListQuery request, CancellationToken cancellationToken)
        {
            var result = (await _transportRepository.ListAllAsync()).OrderBy(x => x.StartDateTime);

            return _mapper.Map<ICollection<TransportListViewModel>>(result);
        }
    }
}
