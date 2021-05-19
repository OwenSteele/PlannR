using MediatR;
using System;

namespace PlannR.Application.Features.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest
    {
        public Guid LocationId { get; set; }
    }
}
