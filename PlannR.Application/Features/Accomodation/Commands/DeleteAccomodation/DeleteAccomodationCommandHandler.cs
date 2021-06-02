using AutoMapper;
using MediatR;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Exceptions;
using PlannR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Commands.DeleteAccomodation
{
    public class DeleteAccomodationCommandHandler : IRequestHandler<DeleteAccomodationCommand>
    {
        private readonly IAccomodationRepository _accomodationRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorisationService<Accomodation> _authorisationService;

        public DeleteAccomodationCommandHandler(IAuthorisationService<Accomodation> authorisationService, IMapper mapper, IAccomodationRepository accomodationRepository)
        {
            _mapper = mapper;
            _authorisationService = authorisationService;
            _accomodationRepository = accomodationRepository;
        }

        public async Task<Unit> Handle(DeleteAccomodationCommand request, CancellationToken cancellationToken)
        {
            var result = await _accomodationRepository.GetByIdAsync(request.AccomodationId);

            if (result == null)
            {
                throw new NotFoundException(nameof(Accomodation), request.AccomodationId);
            }

            if (!_authorisationService.CanAccessEntity(result)) throw new NotAuthorisedException();

            await _accomodationRepository.DeleteAsync(result);

            return Unit.Value;
        }

    }
}
