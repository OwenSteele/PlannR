using PlannR.App.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Routes
{
    public class EditRouteViewModel
    {
        public Guid RouteId { get; set; }
        [Required]
        [NotEmpty]
        public Guid TripId { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ICollection<Guid> Points { get; set; }
    }
}
