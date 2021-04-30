using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Commands.CreateTransport
{
    public class CreateTransportCommandHandler : IRequestHandler<CreateTransportCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly ITransportRepository _transportRepository;


        public CreateTransportCommandHandler(IMapper mapper, ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _transportRepository = transportRepository;
        }

        public async Task<Guid> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTransportCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<Transport>(request);

            entity = await _transportRepository.AddAsync(entity);

            return entity.TransportId;
        }
    }
}
