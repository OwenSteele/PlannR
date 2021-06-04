using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Event> _authorisationService;

        public UpdateEventCommandHandler(IAuthorisationService<Event> authorisationService, IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {

            var result = await _eventRepository.GetByIdAsync(request.EventId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            if (!_authorisationService.CanAlterEntity(result)) throw new NotAuthorisedException();

            var validator = new UpdateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
