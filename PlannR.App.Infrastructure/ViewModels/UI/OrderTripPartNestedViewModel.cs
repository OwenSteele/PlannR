using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.UI
{
    public class OrderTripPartNestedViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StartLocationName { get; set; }
        public (double?,double?) StartCoordinates { get; set; }
        public string EndLocationName { get; set; }
        public (double?, double?) EndCoordinates { get; set; }
        public string Uri { get; set; }
        public string CssClass { get; set; }
    }
}
