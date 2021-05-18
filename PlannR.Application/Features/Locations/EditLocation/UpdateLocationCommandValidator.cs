using FluentValidation;

namespace PlannR.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Latitude)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(p => p.Longitude)
                .NotEmpty().WithMessage("{PropertyName} is required.");
    }
    }
}
