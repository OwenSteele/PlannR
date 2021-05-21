﻿using FluentValidation;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.UpdateAccomodationBooking
{
    public class UpdateAccomodationBookingCommandValidator : AbstractValidator<UpdateAccomodationBookingCommand>
    {
        public UpdateAccomodationBookingCommandValidator()
        {
            RuleFor(p => p.BookingId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.AccomodationId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
