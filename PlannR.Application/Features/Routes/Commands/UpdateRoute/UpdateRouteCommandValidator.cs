using FluentValidation;

namespace PlannR.Application.Features.Routes.Commands.UpdateRoute
{
    public class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommand>
    {
        public UpdateRouteCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TripId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.RouteId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
