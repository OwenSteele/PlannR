using System;

namespace Plannr.App.Infrastructure.ViewModels.Accomodation.Bookings
{
    public class AccomodationBookingListViewModel
    {
        public Guid BookingId { get; set; }
        public Guid AccomodationId { get; set; }
        public string Name { get; set; }
    }
}