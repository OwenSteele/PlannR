using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail
{
    public class GetAccomodationBookingDetailQuery : IRequest<AccomodationBookingDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
