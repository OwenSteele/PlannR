using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingListByTripId
{
    public class GetAccomodationBookingListByTripIdQuery : IRequest<ICollection<AccomodationBookingListByTripIdViewModel>>
    {
        public Guid TripId { get; set; }
    }
}
