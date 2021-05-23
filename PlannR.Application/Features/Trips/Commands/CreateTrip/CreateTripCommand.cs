using MediatR;
using System;

namespace PlannR.Application.Features.Trips.Commands.CreateTrip
{
    public class CreateTripCommand : IRequest<CreateTripCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid? StartLocationId { get; set; }
        public Guid? EndLocationId { get; set; }
    }
}
