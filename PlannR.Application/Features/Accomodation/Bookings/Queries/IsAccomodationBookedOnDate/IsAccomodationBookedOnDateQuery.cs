using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.IsAccomodationBookedOnDate
{
    public class IsAccomodationBookedOnDateQuery : IRequest<ICollection<AccomodationBookedOnDateViewModel>>
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
