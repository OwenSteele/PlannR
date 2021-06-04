using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Event> _authorisationService;

        public DeleteEventCommandHandler(IAuthorisationService<Event> authorisationService, IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var result = await _eventRepository.GetByIdAsync(request.EventId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            await _eventRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
