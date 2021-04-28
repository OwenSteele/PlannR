using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListOnDate
{
    public class GetAccomodationListOnDateQuery : IRequest<ICollection<AccomodationListOnDateViewModel>>
    {
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
    }
}
