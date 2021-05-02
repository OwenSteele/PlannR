using FluentValidation;

namespace PlannR.Application.Features.Accomodations.Commands.CreateAccomodation
{
    public class CreateAccomodationCommandValidator : AbstractValidator<CreateAccomodationCommand>
    {
        public CreateAccomodationCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.TripId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
