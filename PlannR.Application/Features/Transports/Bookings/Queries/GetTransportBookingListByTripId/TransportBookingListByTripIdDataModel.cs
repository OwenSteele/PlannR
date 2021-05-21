using System;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingListByTripId
{
    public class TransportBookingListByTripIdDataModel
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public string Name { get; set; }
    }
}
