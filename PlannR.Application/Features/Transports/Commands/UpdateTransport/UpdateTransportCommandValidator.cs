using FluentValidation;

namespace PlannR.Application.Features.Transports.Commands.UpdateTransport
{
    public class UpdateTransportCommandValidator : AbstractValidator<UpdateTransportCommand>
    {
        public UpdateTransportCommandValidator()
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
