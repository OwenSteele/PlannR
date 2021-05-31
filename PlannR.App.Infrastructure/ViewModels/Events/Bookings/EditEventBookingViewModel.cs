using PlannR.App.Infrastructure.Validation;
using PlannR.App.Infrastructure.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Events.Bookings
{
    public class EditEventBookingViewModel : EditBookingBaseViewModel
    {
        [Required]
        [NotEmpty]
        public Guid EventId { get; set; }
    }
}