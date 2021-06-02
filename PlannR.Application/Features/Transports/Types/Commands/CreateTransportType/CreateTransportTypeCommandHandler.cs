using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Threading;
using System.Threading.Tasks;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Exceptions;

namespace PlannR.Application.Features.Transports.Types.Commands.CreateTransportType
{
    public class CreateTransportTypeCommandHandler : IRequestHandler<CreateTransportTypeCommand, CreateTransportTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TransportType> _transportTypeRepository;
        private readonly IAuthorisationService<TransportType> _authorisationService;


        public CreateTransportTypeCommandHandler(IAuthorisationService<TransportType> authorisationService, IMapper mapper,IAsyncRepository<TransportType> transportTypeRepository)
        {
            _authorisationService = authorisationService;
            _mapper = mapper;
            _transportTypeRepository = transportTypeRepository;
        }

        public async Task<CreateTransportTypeCommandResponse> Handle(CreateTransportTypeCommand request, CancellationToken cancellationToken)
        {
            if (!_authorisationService.CanCreateEntity()) throw new NotAuthorisedException();

            var validator = new CreateTransportTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<TransportType>(request);

            entity = await _transportTypeRepository.AddAsync(entity);

            var response = new CreateTransportTypeCommandResponse
            {
                TransportTypeId = entity.TransportTypeId,
                Success = true
            };

            return response;
        }
    }
}
