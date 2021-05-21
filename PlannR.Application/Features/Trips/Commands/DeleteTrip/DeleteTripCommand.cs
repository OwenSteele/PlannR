using MediatR;
using System;

namespace PlannR.Application.Features.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommand : IRequest
    {
        public Guid TripId { get; set; }
    }
}
