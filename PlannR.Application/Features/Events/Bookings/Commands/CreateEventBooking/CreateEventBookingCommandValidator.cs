using FluentValidation;

namespace PlannR.Application.Features.Events.Bookings.Commands.CreateEventBooking
{
    public class CreateEventBookingCommandValidator : AbstractValidator<CreateEventBookingCommand>
    {
        public CreateEventBookingCommandValidator()
        {
            RuleFor(p => p.EventId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
