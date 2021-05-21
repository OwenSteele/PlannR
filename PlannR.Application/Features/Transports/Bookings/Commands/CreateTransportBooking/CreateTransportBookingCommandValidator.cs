using FluentValidation;

namespace PlannR.Application.Features.Transports.Bookings.Commands.CreateTransportBooking
{
    public class CreateTransportBookingCommandValidator : AbstractValidator<CreateTransportBookingCommand>
    {
        public CreateTransportBookingCommandValidator()
        {
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
