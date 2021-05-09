using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingList
{
    public class GetAccomodationBookingListQuery : IRequest<ICollection<AccomodationBookingListDataModel>>
    {
    }
}
