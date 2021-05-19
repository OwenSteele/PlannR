using PlannR.App.Infrastructure.Validation;
using System;
using System.ComponentModel.DataAnnotations;

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
        public Guid StartLocationId { get; set; }
        public Guid EndLocationId { get; set; }

    }
}
