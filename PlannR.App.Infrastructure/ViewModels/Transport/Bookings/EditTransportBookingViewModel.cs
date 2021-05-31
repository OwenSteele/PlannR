using PlannR.App.Infrastructure.Validation;
using PlannR.App.Infrastructure.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Transport.Bookings
{
    public class EditTransportBookingViewModel : EditBookingBaseViewModel
    {
        [Required]
        [NotEmpty]
        public Guid TransportId { get; set; }
    }
}