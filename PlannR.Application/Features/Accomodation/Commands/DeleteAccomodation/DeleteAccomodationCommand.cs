using MediatR;
using System;

namespace PlannR.Application.Features.Accomodations.Commands.DeleteAccomodation
{
    public class DeleteAccomodationCommand : IRequest
    {
        public Guid AccomodationId { get; set; }
    }
}
