using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Locations
{
    public class LocationDetailViewModel
    {
        public Guid LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AltitudeInMetres { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
