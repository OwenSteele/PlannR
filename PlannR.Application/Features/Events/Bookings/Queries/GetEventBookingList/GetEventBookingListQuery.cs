using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList
{
    public class GetEventBookingListQuery : IRequest<ICollection<EventBookingListDataModel>>
    {
    }
}
