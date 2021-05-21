using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings
{
    public class GetAccomodationListByTripIdWithBookingsQuery : IRequest<ICollection<AccomodationListByTripIdWithBookingsDataModel>>
    {
        public Guid TripId { get; set; }
    }
}
