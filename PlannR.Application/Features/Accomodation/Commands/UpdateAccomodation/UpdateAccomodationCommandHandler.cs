using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Commands.UpdateAccomodation
{
    public class UpdateAccomodationCommandHandler : IRequestHandler<UpdateAccomodationCommand>
    {
        private readonly IAccomodationRepository _accomodationRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Accomodation> _authorisationService;

        public UpdateAccomodationCommandHandler(IAuthorisationService<Accomodation> authorisationService, IMapper mapper, IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<Unit> Handle(UpdateAccomodationCommand request, CancellationToken cancellationToken)
        {

            var result = await _accomodationRepository.GetByIdAsync(request.AccomodationId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Accomodation), request.AccomodationId);
            }

            var validator = new UpdateAccomodationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, result, typeof(UpdateAccomodationCommand), typeof(Accomodation));

            await _accomodationRepository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}
