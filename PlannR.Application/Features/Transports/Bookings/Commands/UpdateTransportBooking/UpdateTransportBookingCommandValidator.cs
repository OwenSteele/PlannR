using FluentValidation;

namespace PlannR.Application.Features.Transports.Bookings.Commands.UpdateTransportBooking
{
    public class UpdateTransportBookingCommandValidator : AbstractValidator<UpdateTransportBookingCommand>
    {
        public UpdateTransportBookingCommandValidator()
        {
            RuleFor(p => p.BookingId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.TransportId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
