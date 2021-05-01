using MediatR;
using System;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingDetail
{
    public class GetEventBookingDetailQuery : IRequest<EventBookingDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
