using MediatR;
using System;

namespace PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType
{
    public class CreateAccomodationTypeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
