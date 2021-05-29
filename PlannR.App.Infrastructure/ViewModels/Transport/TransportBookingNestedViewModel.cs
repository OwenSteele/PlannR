using PlannR.App.Infrastructure.ViewModels.Base;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Transport
{
    public class TransportBookingNestedViewModel : BookingNestedBaseViewModel
    {
        public Guid TransportId { get; set; }
    }
}
