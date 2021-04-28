using FluentValidation;

namespace PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType
{
    public class CreateAccomodationTypeCommandValidator : AbstractValidator<CreateAccomodationTypeCommand>
    {
        public CreateAccomodationTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
