﻿using PlannR.App.Infrastructure.ViewModels.Nested;
using System;

namespace PlannR.App.Infrastructure.ViewModels.Routes
{
    public class RoutePointNestedViewModel
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public Guid? AssociatedEventId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
