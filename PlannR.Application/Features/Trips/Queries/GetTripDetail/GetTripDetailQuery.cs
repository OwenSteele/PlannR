using MediatR;
using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class GetTripDetailQuery : IRequest<TripDetailViewModel>
    {
        public Guid TripId { get; set; }
    }
}
