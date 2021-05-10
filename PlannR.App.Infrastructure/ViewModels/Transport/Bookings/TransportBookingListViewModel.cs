using System;

namespace PlannR.App.Infrastructure.ViewModels.Transport.Bookings
{
    public class TransportBookingListViewModel
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public string Name { get; set; }
    }
}