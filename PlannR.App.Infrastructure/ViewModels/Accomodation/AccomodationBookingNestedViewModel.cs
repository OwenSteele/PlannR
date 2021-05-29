using PlannR.App.Infrastructure.ViewModels.Base;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Accomodation
{
    public class AccomodationBookingNestedViewModel : BookingNestedBaseViewModel
    {
        public Guid AccomodationId { get; set; }
    }
}
