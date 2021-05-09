using System;

namespace Plannr.App.Infrastructure.ViewModels.Transport.Bookings
{
    public class TransportBookingOfTripListViewModel
    {
        public Guid BookingId { get; set; }
        public Guid TransportId { get; set; }
        public string Name { get; set; }
    }
}