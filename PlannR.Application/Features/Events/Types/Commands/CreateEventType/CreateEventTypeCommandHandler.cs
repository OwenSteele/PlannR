using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.EntityTypes;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Commands.CreateEventType
{
    public class CreateEventTypeCommandHandler : IRequestHandler<CreateEventTypeCommand, CreateEventTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventType> _eventTypeRepository;
        private readonly IAuthorisationService<EventType> _authorisationService;


        public CreateEventTypeCommandHandler(IAuthorisationService<EventType> authorisationService, IMapper mapper, IAsyncRepository<EventType> eventTypeRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
            _authorisationService = authorisationService;
        }

        public async Task<CreateEventTypeCommandResponse> Handle(CreateEventTypeCommand request, CancellationToken cancellationToken)
        {
            if (!_authorisationService.CanCreateEntity()) throw new NotAuthorisedException();

            var validator = new CreateEventTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<EventType>(request);

            entity = await _eventTypeRepository.AddAsync(entity);

            var response = new CreateEventTypeCommandResponse
            {
                EventTypeId = entity.EventTypeId,
                Success = true
            };

            return response;
        }
    }
}
