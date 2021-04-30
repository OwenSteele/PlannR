using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Queries.GetTripsDetail
{
    public class GetTripDetailQuery : IRequest<TripDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
