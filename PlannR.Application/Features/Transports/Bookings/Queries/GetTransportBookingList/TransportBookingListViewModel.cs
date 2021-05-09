using System;

namespace PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingList
{
    public class TransportBookingListDataModel
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}
