using PlannR.App.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings
{
    public class EditAccomodationBookingViewModel
    {
        [Required]
        public Guid BookingId { get; set; }
        [Required]
        [NotEmpty]
        public Guid AccomodationId { get; set; }
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
