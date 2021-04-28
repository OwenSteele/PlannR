using AutoMapper;
using MediatR;
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

        public DeleteTransportCommandHandler(IMapper mapper, ITransportRepository transportRepository)
        {
            _mapper = mapper;
            _transportRepository = transportRepository;
        }

        public async Task<Unit> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {
            var result = await _transportRepository.GetByIdAsync(request.TransportId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Transport), request.TransportId);
            }

            await _transportRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
