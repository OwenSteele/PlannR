using System;

namespace PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings
{
    public class TransportBookingDto
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}