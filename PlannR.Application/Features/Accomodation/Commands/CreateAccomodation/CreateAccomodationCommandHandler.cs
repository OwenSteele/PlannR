using AutoMapper;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Commands.CreateAccomodation
{
    public class CreateAccomodationCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IAccomodationRepository _accomodationRepository;


        public CreateAccomodationCommandHandler(IMapper mapper, IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<Guid> Handle(CreateAccomodationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccomodationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var entity = _mapper.Map<Accomodation>(request);

            entity = await _accomodationRepository.AddAsync(entity);

            return entity.AccomodationId;
        }
    }
}
