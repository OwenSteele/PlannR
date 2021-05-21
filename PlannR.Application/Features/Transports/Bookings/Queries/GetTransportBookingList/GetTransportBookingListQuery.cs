using MediatR;
using System.Collections.Generic;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingList
{
    public class GetTransportBookingListQuery : IRequest<ICollection<TransportBookingListDataModel>>
    {
    }
}
