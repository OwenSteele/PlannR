using PlannR.App.Infrastructure.Validation;
using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class EditTripViewModel
    {
        [Required]
        public Guid TripId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DateInFuture]
        public DateTime StartDateTime { get; set; }
        [Required]
        [DateInFuture]
        public DateTime EndDateTime { get; set; }
    }
}
