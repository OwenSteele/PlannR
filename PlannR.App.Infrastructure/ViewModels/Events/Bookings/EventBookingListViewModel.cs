using System;

namespace Plannr.App.Infrastructure.ViewModels.Event.Bookings
{
    public class EventBookingListViewModel
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
    }
}