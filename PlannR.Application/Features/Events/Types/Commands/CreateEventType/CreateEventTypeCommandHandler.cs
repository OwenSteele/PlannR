using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Events.Types.Commands.CreateEventType
{
    public class CreateEventTypeCommandHandler : IRequestHandler<CreateEventTypeCommand, CreateEventTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EventType> _eventTypeRepository;


        public CreateEventTypeCommandHandler(IMapper mapper, IAsyncRepository<EventType> eventTypeRepository)
        {
            _mapper = mapper;
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<CreateEventTypeCommandResponse> Handle(CreateEventTypeCommand request, CancellationToken cancellationToken)
        {
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
