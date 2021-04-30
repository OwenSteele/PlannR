using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingDetail
{
    public class GetEventBookingDetailQuery : IRequest<EventBookingDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
