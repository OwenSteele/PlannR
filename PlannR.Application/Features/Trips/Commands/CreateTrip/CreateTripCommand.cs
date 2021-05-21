using MediatR;
using System;

namespace PlannR.Application.Features.Trips.Commands.CreateTrip
{
    public class CreateTripCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
