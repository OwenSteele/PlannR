using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class EventNestedViewModel
    {
        public Guid EventId { get; set; }
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
