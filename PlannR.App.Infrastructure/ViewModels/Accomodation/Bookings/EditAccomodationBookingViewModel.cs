using PlannR.App.Infrastructure.Validation;
using PlannR.App.Infrastructure.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings
{
    public class EditAccomodationBookingViewModel : EditBookingBaseViewModel
    {
        [Required]
        [NotEmpty]
        public Guid AccomodationId { get; set; }
    }
}
