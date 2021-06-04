using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Commands.UpdateTransport
{
    public class UpdateTransportCommandHandler : IRequestHandler<UpdateTransportCommand>
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Transport> _authorisationService;

        public UpdateTransportCommandHandler(IAuthorisationService<Transport> authorisationService, IMapper mapper, ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportRepository = transportRepository;
        }

        public async Task<Unit> Handle(UpdateTransportCommand request, CancellationToken cancellationToken)
        {

            var result = await _transportRepository.GetByIdAsync(request.TransportId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Event), request.TransportId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            var validator = new UpdateTransportCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateTransportCommand), typeof(Transport));

            await _transportRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
