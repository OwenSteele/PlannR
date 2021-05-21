using FluentValidation;

namespace PlannR.Application.Features.Accomodations.Commands.UpdateAccomodation
{
    public class UpdateAccomodationCommandValidator : AbstractValidator<UpdateAccomodationCommand>
    {
        public UpdateAccomodationCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TripId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.AccomodationId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
