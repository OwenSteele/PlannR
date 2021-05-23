using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType
{
    public class CreateAccomodationTypeCommandHandler : IRequestHandler<CreateAccomodationTypeCommand, CreateAccomodationTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AccomodationType> _accomodationTypeRepository;


        public CreateAccomodationTypeCommandHandler(IMapper mapper, IAsyncRepository<AccomodationType> accomodationTypeRepository)
        {
            _mapper = mapper;
            _accomodationTypeRepository = accomodationTypeRepository;
        }

        public async Task<CreateAccomodationTypeCommandResponse> Handle(CreateAccomodationTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccomodationTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<AccomodationType>(request);

            entity = await _accomodationTypeRepository.AddAsync(entity);

            var response = new CreateAccomodationTypeCommandResponse
            {
                AccomodationTypeId = entity.AccomodationTypeId,
                Success = true
            };

            return response;
        }
    }
}
