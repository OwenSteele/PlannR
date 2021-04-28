using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Bookings.Queries.IsEventBookedOnDate
{
    public class IsEventBookedOnDateQuery : IRequest<ICollection<EventBookedOnDateViewModel>>
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
