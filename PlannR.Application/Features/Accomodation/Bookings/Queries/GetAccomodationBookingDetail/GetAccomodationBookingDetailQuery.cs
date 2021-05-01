using MediatR;
using System;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail
{
    public class GetAccomodationBookingDetailQuery : IRequest<AccomodationBookingDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
