using PlannR.App.Infrastructure.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Base
{
    public class EditBookingBaseViewModel
    {
        [Required]
        public Guid BookingId { get; set; }
        [Required]
        [NotEmpty]
        public string Name { get; set; }
        [Url]
        public string Link { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}
