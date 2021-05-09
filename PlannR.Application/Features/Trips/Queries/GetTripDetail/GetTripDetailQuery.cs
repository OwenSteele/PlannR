using MediatR;
using System;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class GetTripDetailQuery : IRequest<TripDetailDataModel>
    {
        public Guid TripId { get; set; }
    }
}
