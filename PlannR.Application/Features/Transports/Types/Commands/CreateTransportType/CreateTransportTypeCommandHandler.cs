using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Types.Commands.CreateTransportType
{
    public class CreateTransportTypeCommandHandler : IRequestHandler<CreateTransportTypeCommand, CreateTransportTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TransportType> _transportTypeRepository;


        public CreateTransportTypeCommandHandler(IMapper mapper, IAsyncRepository<TransportType> transportTypeRepository)
        {
            _mapper = mapper;
            _transportTypeRepository = transportTypeRepository;
        }

        public async Task<CreateTransportTypeCommandResponse> Handle(CreateTransportTypeCommand request, CancellationToken cancellationToken)
        {
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
