﻿using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Commands.DeleteRoute
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand>
    {
        private readonly IRouteRepository _accomodationRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Route> _authorisationService;

        public DeleteRouteCommandHandler(IAuthorisationService<Route> authorisationService, IMapper mapper, IRouteRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var result = await _accomodationRepository.GetByIdAsync(request.RouteId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Route), request.RouteId);
            }

            await _accomodationRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
