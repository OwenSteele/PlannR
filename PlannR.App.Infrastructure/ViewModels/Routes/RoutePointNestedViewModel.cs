using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Routes
{
    public class RoutePointNestedViewModel
    {
        public Guid Id { get; set; }
        public LocationNestedViewModel Location { get; set; }
        public Guid AssociatedEventId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
