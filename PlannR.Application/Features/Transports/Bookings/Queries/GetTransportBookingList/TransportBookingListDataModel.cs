using System;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingList
{
    public class TransportBookingListDataModel
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public string Name { get; set; }
    }
}
