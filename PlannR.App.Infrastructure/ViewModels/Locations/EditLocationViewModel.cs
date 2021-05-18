using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Locations
{
    public class EditLocationViewModel
    {
        public Guid LocationId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public double AltitudeInMetres { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
