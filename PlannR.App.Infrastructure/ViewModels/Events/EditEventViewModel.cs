using PlannR.App.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Events
{
    public class EditEventViewModel
    {
        public Guid EventId { get; set; }
        [Required]
        [NotEmpty]
        public Guid TripId { get; set; }
        [Required]
        [NotEmpty]
        public string Name { get; set; }
        public string CompanyName { get; set; }
        [Required]
        [NotEmpty]
        public Guid EventTypeId { get; set; }
        public Guid? BookingId { get; set; }
        public string Description { get; set; }
        public Guid? LocationId { get; set; }
        [Required]
        [NotEmpty]
        public DateTime StartDateTime { get; set; }
        [Required]
        [NotEmpty]
        public DateTime EndDateTime { get; set; }
    }
}
