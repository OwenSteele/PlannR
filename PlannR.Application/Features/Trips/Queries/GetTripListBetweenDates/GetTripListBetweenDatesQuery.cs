using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Queries.GetTripListBetweenDates
{
    public class GetTripListBetweenDatesQuery : IRequest<ICollection<TripListBetweenDatesViewModel>>
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
