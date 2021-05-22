using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, CreateRouteCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _accomodationRepository;


        public CreateRouteCommandHandler(IMapper mapper, IRouteRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<CreateRouteCommandResponse> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRouteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<Route>(request);

            entity = await _accomodationRepository.AddAsync(entity);

            var response = new CreateRouteCommandResponse
            {
                RouteId = entity.RouteId,
                Success = true
            };

            return response;
        }
    }
}
