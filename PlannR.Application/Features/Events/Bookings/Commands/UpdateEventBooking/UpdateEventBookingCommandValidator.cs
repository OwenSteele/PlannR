using FluentValidation;

namespace PlannR.Application.Features.Events.Bookings.Commands.UpdateEventBooking
{
    public class UpdateEventBookingCommandValidator : AbstractValidator<UpdateEventBookingCommand>
    {
        public UpdateEventBookingCommandValidator()
        {
            RuleFor(p => p.BookingId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

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
