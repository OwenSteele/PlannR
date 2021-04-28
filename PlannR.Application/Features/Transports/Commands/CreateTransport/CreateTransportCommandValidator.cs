using FluentValidation;
using PlannR.Application.Contracts.Persistence;
using System;

namespace PlannR.Application.Features.Transports.Commands.CreateTransport
{
    public class CreateTransportCommandValidator : AbstractValidator<CreateTransportCommand>
    {
        public CreateTransportCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
