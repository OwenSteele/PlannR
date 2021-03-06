using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Trips.Queries.GetTripListOnDate
{
    public class GetTripListOnDateQuery : IRequest<ICollection<TripListOnDateDataModel>>
    {
        public DateTime DateTime { get; set; }
    }
}
