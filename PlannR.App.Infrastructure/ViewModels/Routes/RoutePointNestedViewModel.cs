using PlannR.App.Infrastructure.Validation;
using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Routes
{
    public class RoutePointNestedViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [NotEmpty]
        public Guid LocationId { get; set; }
        public Guid? AssociatedEventId { get; set; }
        [Required]
        [NotEmpty]
        public DateTime StartDateTime { get; set; }
        [Required]
        [NotEmpty]
        public DateTime EndDateTime { get; set; }
    }
}
