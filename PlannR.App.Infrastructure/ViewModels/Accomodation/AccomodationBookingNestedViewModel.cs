﻿using System;

namespace PlannR.App.Infrastructure.ViewModels.Accomodation
{
    public class AccomodationBookingNestedViewModel
    {
        public Guid BookingId { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
    }
}