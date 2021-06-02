using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Transports.Commands.DeleteTransport
{
    public class DeleteTransportCommandHandler : IRequestHandler<DeleteTransportCommand>
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Transport> _authorisationService;

        public DeleteTransportCommandHandler(IAuthorisationService<Transport> authorisationService, IMapper mapper, ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _transportRepository = transportRepository;
        }

        public async Task<Unit> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {
            var result = await _transportRepository.GetByIdAsync(request.TransportId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Transport), request.TransportId);
            }

            if (!_authorisationService.CanAccessEntity(result)) throw new NotAuthorisedException();

            await _transportRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
