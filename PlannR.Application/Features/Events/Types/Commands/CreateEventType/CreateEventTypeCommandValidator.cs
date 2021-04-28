using FluentValidation;

namespace PlannR.Application.Features.Events.Types.Commands.CreateEventType
{
    public class CreateEventTypeCommandValidator : AbstractValidator<CreateEventTypeCommand>
    {
        public CreateEventTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
